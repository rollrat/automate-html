/* Copyright (C) 2018-2019. rollrat All Rights Reserved. */

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automate_html_gui.Core
{
    public class HTMLTree
    {
        HtmlNode root_node;
        List<List<HtmlNode>> depth_map;
        public int Height { get { return depth_map.Count - 1; } }

        public List<HtmlNode> this[int i]
        {
            get { return depth_map[i]; }
        }

        public HTMLTree(string html)
        {
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            root_node = document.DocumentNode;
        }

        public void BuildTree(int lower_bound = 0, int upper_bound = int.MaxValue)
        {
            depth_map = new List<List<HtmlNode>>();

            var queue = new Queue<Tuple<int, HtmlNode>>();
            var nodes = new List<HtmlNode>();
            int latest_depth = 0;

            queue.Enqueue(Tuple.Create(0, root_node));

            while (queue.Count > 0)
            {
                var e = queue.Dequeue();

                if (e.Item1 != latest_depth)
                {
                    depth_map.Add(nodes);
                    nodes = new List<HtmlNode>();
                    latest_depth = e.Item1;
                }

                if (lower_bound <= latest_depth)
                    nodes.Add(e.Item2);

                if (latest_depth < upper_bound && e.Item2.HasChildNodes)
                {
                    foreach (var node in e.Item2.ChildNodes)
                    {
                        queue.Enqueue(Tuple.Create(e.Item1 + 1, node));
                    }
                }
            }

            if (nodes.Count > 0)
                depth_map.Add(nodes);
        }
    }
}
