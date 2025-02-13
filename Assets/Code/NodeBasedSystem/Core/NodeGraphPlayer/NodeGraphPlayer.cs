using System.Collections.Generic;
using System.Linq;
using Code.NodeBasedSystem.Core.Conditions;
using Code.NodeBasedSystem.Core.NodeSystemEntities;
using Code.NodeBasedSystem.GraphLoaders;
using Code.NodeBasedSystem.GraphPlayer;
using Entitas;
using NodeBasedSystem.Nodes;
using UnityEngine;

namespace Code.NodeBasedSystem.Core.NodeGraphPlayer
{
    public class NodeGraphPlayer : IGraphPlayer
    {
        private readonly NodeSystemContext _context;
        private readonly IGraphLoader _graphLoader;
        private readonly INodeConditionVerifyService _verifier;
        private readonly string _graphPlayerIdentifier;
        
        private IEnumerable<NodeSystemEntity> _targetGraphGroup;
        private NodeSystemEntity _localStorage;

        public NodeGraphPlayer(
            NodeSystemContext context, 
            INodeConditionVerifyService verifier,
            IGraphLoader graphLoader, 
            string identifier)
        {
            _graphPlayerIdentifier = identifier;
            _context = context;
            _verifier = verifier;
            _graphLoader = graphLoader;
            _targetGraphGroup = null;
        }

        public void StartGraph(string staticDataId)
        {
            Release();

            _graphLoader.LoadGraph(staticDataId, _graphPlayerIdentifier);
            _targetGraphGroup = FindTargetGraph();
            AssignGraphPlayer();
            
            _localStorage = CreateNodeSystemEntity.LocalTokenStorage(_graphPlayerIdentifier);

            NodeSystemEntity startNode = _targetGraphGroup
                .FirstOrDefault(entity => entity.isStartNode);

            if (startNode == null)
            {
                Debug.LogError($"[NODE_GRAPH_PLAYER] the starting node was not found in the graph {_graphPlayerIdentifier} with staticDataID = {staticDataId}");
                return;
            }

            PlayNode(startNode.nodeId.Value);
        }

        private void AssignGraphPlayer()
        {
            foreach (NodeSystemEntity entity in _targetGraphGroup)
            {
                entity.ReplaceGraphPlayer(this);
                AssignGraphPlayerToConditions(entity);
            }
        }

        private void AssignGraphPlayerToConditions(NodeSystemEntity entity)
        {
            if (entity.hasNextNodes)
            {
                foreach (var nextNode in entity.NextNodes)
                {
                    nextNode.Conditions.ForEach(c => 
                        c.GraphPlayerID = _graphPlayerIdentifier);
                }
            }
        }

        private IEnumerable<NodeSystemEntity> FindTargetGraph()
        {
            IGroup<NodeSystemEntity> allNodes =
                            _context.GetGroup(NodeSystemMatcher.AllOf(
                            NodeSystemMatcher.GraphID,
                            NodeSystemMatcher.NodeId));

            return allNodes
                .GetEntities()
                .Where(entity => entity.graphID.Value == _graphPlayerIdentifier);
        }

        public void Release()
        {
            List<NodeSystemEntity> group = FindTargetGraph().ToList();

            for (int i = 0; i < group.Count(); i++)
            {
                group[i].Destroy();
            }
            
            _localStorage?.Destroy();
        }

        public void PlayNode(string nodeId)
        {
            UnmarkAllNodes();
            MarkTargetNode(nodeId);
        }

        public void PlayNextNode()
        {
            NodeSystemEntity currentNode 
                = _targetGraphGroup.FirstOrDefault(n 
                    => n.isPlaying && n.Node != ENodeType.Choices);

            if (currentNode == null)
            {
                Debug.LogWarning($"Not found next available node in graph {_graphPlayerIdentifier}");
                return;
            }

            switch (currentNode.Node)
            {
                case ENodeType.Simple:
                    PlaySimpleNode(currentNode);
                    break;
                case ENodeType.Conditional:
                    PlayConditionedNode(currentNode);
                    break;
            }
        }

        private void PlayConditionedNode(NodeSystemEntity currentNode)
        {
            ConditionNodeLink link = currentNode.NextNodes
                .FirstOrDefault(n => _verifier.Check(n.Conditions.ToArray()));

            if (link == null)
            {
                Debug.LogError($"[NodeGraphPlayer] Not found next available node by conditions in graph {_graphPlayerIdentifier}");
                return;
            }
            string nextNodeId = link.NodeId;
            PlayNode(nextNodeId);
        }

        private void PlaySimpleNode(NodeSystemEntity currentNode)
        {
            ConditionNodeLink nextLink = currentNode.NextNodes.FirstOrDefault();
                
            if (nextLink == null)
            {
                Debug.LogWarning($"[NodeGraphPlayer] Not found next available node in graph {_graphPlayerIdentifier}");
                return;
            }
                
            PlayNode(nextLink.NodeId); 
        }

        private void MarkTargetNode(string nodeId)
        {
            NodeSystemEntity targetNode = _targetGraphGroup
                .FirstOrDefault(node => node.nodeId.Value == nodeId);

            if (targetNode == null)
            {
                Debug.LogError($"[NODE_GRAPH_PLAYER] the node with id = {nodeId} was not found in the graph {_graphPlayerIdentifier}");
                return;
            }

            targetNode.isPlaying = true;
            targetNode.isPlayed = true;
        }

        private void UnmarkAllNodes()
        {
            foreach (NodeSystemEntity node in _targetGraphGroup)
            {
                if (node.isPlaying)
                    node.isPlaying = false;
            }
        }
    }
}