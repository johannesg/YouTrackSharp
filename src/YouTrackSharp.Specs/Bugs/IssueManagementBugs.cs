﻿#region License
// Distributed under the BSD License
//  
// YouTrackSharp Copyright (c) 2011-2011, Hadi Hariri and Contributors
// All rights reserved.
//  
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//     * Redistributions of source code must retain the above copyright
//        notice, this list of conditions and the following disclaimer.
//     * Redistributions in binary form must reproduce the above copyright
//        notice, this list of conditions and the following disclaimer in the
//        documentation and/or other materials provided with the distribution.
//     * Neither the name of Hadi Hariri nor the
//        names of its contributors may be used to endorse or promote products
//        derived from this software without specific prior written permission.
//  
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
//  TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
//  PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL 
//  <COPYRIGHTHOLDER> BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
//  SPECIAL,EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
//  LIMITED  TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
//  DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND  ON ANY
//  THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
//  (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
//  THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//  
#endregion

using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using YouTrackSharp.Issues;
using YouTrackSharp.Specs.Helpers;

namespace YouTrackSharp.Specs.Bugs
{
    public class YTSRP9 :AuthenticatedYouTrackConnectionForIssue
    {
        Because of = () => { issues = issueManagement.GetAllIssuesForProject("SB", 1); };

        It should_return_single_issue = () => issues.Count().ShouldEqual(1);

        It should_contain_valid_issue_id = () => issues.First().Id.ShouldNotBeEmpty();

        protected static IEnumerable<Issue> issues;
    }

    public class YTSRP15: AuthenticatedYouTrackConnectionForIssue
    {
        Because of = () => { issue = issueManagement.GetIssue("SB-12"); };

        It should_contain_assignee = () => { issue.Assignee.ShouldEqual("hhariri"); };

        static Issue issue;
    }


    public class YTSRP17 : AuthenticatedYouTrackConnectionForIssue
    {
        Because of = () => { comments = issueManagement.GetCommentsForIssue("SB-35"); };

        It should_retrieve_one_comment = () => { comments.First().Text.ShouldNotBeEmpty(); };

        static IEnumerable<Comment> comments;
    }   

    public class YTSRP18 : AuthenticatedYouTrackConnectionForIssue
    {
        Because of = () => { comments = issueManagement.GetCommentsForIssue("SB-36"); };

        It should_return_zero_comments = () => { comments.Count().ShouldEqual(0); };

        static IEnumerable<Comment> comments;
    }   


}