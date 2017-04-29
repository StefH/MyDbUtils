//#define LOGIC_TEST	// comment for production, uncomment for test sample

using System;
using System.Collections.Generic;
using System.Linq;

// (c) Gregory Adam 2009

//http://www.brpreiss.com/books/opus4/html/page557.html
/*   and
 * An Introduction to data structures with applications
 *   Jean-Paul Tremblay - Paul G. Sorensen
 *   pages 494-497
 *   
 * Topological sort of a forest of directed acyclic graphs
 * 
 * The algorithm is pretty straight
 * for each node, a list of succesors is built
 * each node contains its indegree  (predecessorCount)
 *
 * (1) create a queue containing the key of every node that has no predecessors
 * (2) while (the queue is not empty)
 *      dequeue()
 *      output the key
 *      remove the key
 *      
 *      for each node in the successorList
 *          decrement its predecessorCount
 *          if the predecessorCount becomes empty, add it to the queue
 * 
 * 
 * (3) if any node left, then there is a least one cycle
 *
 */

// <T> has to implement IEquatable
// <T> cannot be null - since IDictionary is used

/*
 * 	using GregoryAdam.Base.Graph
 *		var obj = new Graph.TopologicalSort<T>();		
 */

/* Methods
 * 
 * public bool Edge(Node)
 *	returns true or false
 *	
 * public bool Edge(successor, predecessor)
 *	returns true or false
 *	
 *  public bool Sort(out Queue<T> outQueue)
 *  if true
 *		returns the evaluation queue
 *	else
 *		returns a queue with one cycle
 */
// ReSharper disable once CheckNamespace
namespace GregoryAdam.Base.Graph
{
    public sealed class TopologicalSort<T> where T : IEquatable<T>
    {
        #region Properties
        #region Properties Private
        private readonly Dictionary<T, NodeInfo> _nodes = new Dictionary<T, NodeInfo>();
        #endregion Properties Private
        #endregion Properties
        #region Methods
        #region Methods Public
        //-------------------------------------------------------------------------
        /// <summary>
        /// Adds a node with nodeKey
        /// Does not complain if the node is already present
        /// </summary>
        /// <param name="nodeKey"></param>
        /// <returns>
        ///		true on success
        ///		false if the nodeKey is null
        /// </returns>
        public bool Edge(T nodeKey)
        {
            if (nodeKey == null)
                return false;

            if (!_nodes.ContainsKey(nodeKey))
                _nodes.Add(nodeKey, new NodeInfo());

            return true;
        }
        //-------------------------------------------------------------------------
        /// <summary>
        /// Add an Edge where successor depends on predecessor
        /// Does not complain if the directed arc is already in
        /// </summary>
        /// <param name="successor"></param>
        /// <param name="predecessor"></param>
        /// <returns>
        ///		true on success
        ///		false if either parameter is null
        ///			or successor equals predecessor
        /// </returns>
        public bool Edge(T successor, T predecessor)
        {
            // make sure both nodes are there
            if (!Edge(successor)) return false;
            if (!Edge(predecessor)) return false;

            // if successor == predecessor (cycle) fail
            if (successor.Equals(predecessor)) return false;

            var successorsOfPredecessor = _nodes[predecessor].Successors;

            // if the Edge is already there, keep silent
            if (!successorsOfPredecessor.Contains(successor))
            {
                // add the sucessor to the predecessor's successors
                successorsOfPredecessor.Add(successor);

                // increment predecessorrCount of successor
                _nodes[successor].PredecessorCount++;
            }
            return true;

        }

        //-------------------------------------------------------------------------
        public bool Sort(out Queue<T> sortedQueue)
        {
            sortedQueue = new Queue<T>(); // create, even if it stays empty

            var outputQueue = new Queue<T>(); // with predecessorCount == 0

            // (1) go through all the nodes
            //		if the node's predecessorCount == 0
            //			add it to the outputQueue
            foreach (var kvp in _nodes.Where(kvp => kvp.Value.PredecessorCount == 0))
            {
                outputQueue.Enqueue(kvp.Key);
            }

            // (2) process the output Queue
            //	output the key
            //	delete the key from Nodes
            //	foreach successor
            //		decrement its predecessorCount
            //		if it becomes zero
            //			add it to the output Queue

            while (outputQueue.Count != 0)
            {
                var nodeKey = outputQueue.Dequeue();

                sortedQueue.Enqueue(nodeKey); // add it to sortedQueue

                var nodeInfo = _nodes[nodeKey];

                _nodes.Remove(nodeKey);	// remove it from Nodes

                foreach (T successor in nodeInfo.Successors.Where(successor => --_nodes[successor].PredecessorCount == 0))
                {
                    outputQueue.Enqueue(successor);
                }

                nodeInfo.Clear();
            }

            // outputQueue is empty here
            if (_nodes.Count == 0)
            {
                return true; // if there are no nodes left in Nodes, return true
            }

            // there is at least one cycle
            CycleInfo(sortedQueue); // get one cycle in sortedQueue
            return false; // and fail
        }

        //-------------------------------------------------------------------------
        /// <summary>
        /// Clears the Nodes for reuse.  Note that Sort() already does this
        /// </summary>
        public void Clear()
        {
            foreach (NodeInfo nodeInfo in _nodes.Values)
                nodeInfo.Clear();

            _nodes.Clear();
        }

        //-------------------------------------------------------------------------
        #endregion Methods Public
        #region Methods Private
        /// <summary>
        /// puts one cycle in cycleQueue
        /// </summary>
        /// <param name="cycleQueue"></param>
        public void CycleInfo(Queue<T> cycleQueue)
        {
            cycleQueue.Clear(); // Clear the queue, it may have data in it

            // init  Cycle info of remaining nodes
            foreach (NodeInfo nodeInfo in _nodes.Values)
                nodeInfo.ContainsCycleKey = nodeInfo.CycleWasOutput = false;

            // (1) put the predecessor in the CycleKey of the successor
            T cycleKey = default(T);
            bool cycleKeyFound = false;

            foreach (var kvp in _nodes)
            {
                foreach (T successor in kvp.Value.Successors)
                {
                    var successorInfo = _nodes[successor];

                    if (!successorInfo.ContainsCycleKey)
                    {
                        successorInfo.CycleKey = kvp.Key;
                        successorInfo.ContainsCycleKey = true;

                        if (!cycleKeyFound)
                        {
                            cycleKey = kvp.Key;
                            cycleKeyFound = true;
                        }
                    }
                }
                kvp.Value.Clear();
            }

            if (!cycleKeyFound)
            {
                throw new Exception("program error: !cycleKeyFound");
            }

            // (2) put a cycle in cycleQueue
            NodeInfo cycleNodeInfo;
            while (!(cycleNodeInfo = _nodes[cycleKey]).CycleWasOutput)
            {
                if (!cycleNodeInfo.ContainsCycleKey)
                    throw new Exception("program error: nodeInfo.ContainsCycleKey");

                cycleQueue.Enqueue(cycleKey);
                cycleNodeInfo.CycleWasOutput = true;
                cycleKey = cycleNodeInfo.CycleKey;
            }
        }
        #endregion Methods Private
        #endregion Methods

        #region Classes Nested
        private class NodeInfo
        {
            // for construction
            public int PredecessorCount;
            public readonly List<T> Successors = new List<T>();

            // for Cycles in case the sort fails
            public T CycleKey;
            public bool ContainsCycleKey;
            public bool CycleWasOutput;

            // Clear NodeInfo
            public void Clear()
            {
                Successors.Clear();
            }

        }
        #endregion Classes Nested
    }
#if LOGIC_TEST
	public static class TopologicalSortTest
	{
		public static void Main()
		{
			LogicTest_OK();
			LogicTest_NotOk();
			Console.ReadLine();
		}

		/*
		 * a = b + c
		 * c = d + e
		 * 
		 * should get b d e c a (or d e c b a)
		*/
		public static bool LogicTest_OK()
		{
			var ts = new TopologicalSort<string>();
			Queue<string> outQueue;

			bool returnValue;

			ts.Edge("a", "b");
			ts.Edge("a", "c");

			ts.Edge("c", "d");
			ts.Edge("c", "e");

			returnValue = ts.Sort(out outQueue);

			Console.WriteLine(" should get (b d e c a) or (d e c b a)");

			while (outQueue.Count != 0)
				Console.WriteLine(" > {0}", outQueue.Dequeue());

			Console.WriteLine("Expected true, got {0}, success = {1}",
				returnValue, returnValue);

			return returnValue;
		}
		public static bool LogicTest_NotOk()
		{
			var ts = new TopologicalSort<string>();
			Queue<string> outQueue;

			bool returnValue;

			ts.Edge("a", "b");
			ts.Edge("a", "c");

			ts.Edge("c", "d");
			ts.Edge("c", "e");

			ts.Edge("e", "a");

			returnValue = ts.Sort(out outQueue);

			Console.WriteLine(" should get a cycle of (a c e)");

			while (outQueue.Count != 0)
				Console.WriteLine(" > {0}", outQueue.Dequeue());

			Console.WriteLine("Expected false, got {0}, success = {1}",
				returnValue, !returnValue);

			return returnValue;
		}
	}
#endif
}
