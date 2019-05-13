﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorDashboard.Shared.Models;

namespace BlazorDashboard.Server.Data
{
    public static class IssuesGenerator
    {
        public static async Task<IEnumerable<Issue>> GenerateIssues(DateTime timeRange)
        {
            //in a real case this can be calling an actual database. Here, we generate data "randomly"

            DateTime currTime = DateTime.Now;
            int daysToGenerateIssueFor = ((TimeSpan)(currTime - timeRange)).Days;
            List<Issue> issueList = new List<Issue>();

            for (int i = daysToGenerateIssueFor; i >= 0; i--)
            {
                for (int j = 0; j < rand.Next(1, 4); j++)
                {
                    Issue currIssue = new Issue();

                    currIssue.Id = daysToGenerateIssueFor - i;
                    currIssue.Title = _dummyTitle.Substring(rand.Next(5, _dummyTitle.Length)) + currIssue.Id;
                    currIssue.CreatedOn = currTime.AddDays(-i);
                    if (rand.Next(0, 10) % rand.Next(1, 4) == 0)
                    {
                        currIssue.ClosedOn = currTime.AddDays(-rand.Next(0, rand.Next(0, i)));
                    }

                    int type = rand.Next(0, 3);
                    currIssue.Type = (IssueType)type;
                    currIssue.Labels = new List<string>();
                    currIssue.Labels.Add(_issueTypes[type]);
                    if (currIssue.Type == IssueType.Bug)
                    {
                        int sev = rand.Next(0, 3);
                        currIssue.Severity = (IssueSeverity)sev;
                        currIssue.Labels.Add(_severities[sev]);
                    }
                    currIssue.Labels.Add("team " + rand.Next(1, 3));
                    currIssue.Labels.Add("priority " + rand.Next(1, 7));
                    currIssue.Labels.Add(_componentList[rand.Next(0, _componentList.Length - 1)]);
                    currIssue.Labels.Add(rand.Next(0, 20) % 6 == 0 ? "appearance" : "functionality");
                    currIssue.Labels.Add(currIssue.IsOpen ? "open" : "closed");

                    currIssue.Description = "<p style=\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif; background-color: #ffffff;\"><strong>Lorem ipsum </strong>dolor sit amet, consectetur adipiscing elit. Nam eget diam et ipsum vulputate porta. Duis non venenatis odio, ut sagittis mi. Nam et pellentesque dolor. Pellentesque ornare neque ac feugiat convallis:</p><ul>	<li style =\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif; background-color: #ffffff;\"> Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. </li><li style =\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif; background-color: #ffffff;\">In ac eros eget elit laoreet congue vitae vel quam. </li><li style =\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif; background-color: #ffffff;\">Suspendisse potenti. </li><li style =\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif; background-color: #ffffff;\">Fusce vitae magna maximus, ornare turpis quis, porttitor velit. Nam ac condimentum massa, vitae tristique nulla.</li></ul><h5 style =\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif; background-color: #ffffff;\">Vestibulum vitae ante egestas, sollicitudin justo a, pulvinar turpis.</h5><p style =\"margin: 0px 0px 15px; padding: 0px; text-align: justify; font-family: 'Open Sans', Arial, sans-serif; background-color: #ffffff;\"> Sed at condimentum turpis. Mauris fermentum, felis non euismod sagittis, nisl dui bibendum urna, vel iaculis mi nunc dictum turpis. In sodales at sapien eget pellentesque.</p>";

                    issueList.Add(currIssue);
                }
            }

            return issueList;
        }

        private static Random rand = new Random();
        private static string _dummyTitle = "Issue lorem ipsum dolor sit amet, consectetur adipiscing elit.";
        private static string[] _issueTypes = { "bug", "feature", "enhancement" };
        private static string[] _severities = { "low", "medium", "high" };
        private static string[] _componentList = { "grid", "button", "window", "chart", "textbox", "numeric textbox", "dropdownlist", "calendar" };
    }
}
