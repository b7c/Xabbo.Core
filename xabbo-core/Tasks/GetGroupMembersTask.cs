﻿using System;
using System.Threading.Tasks;

using Xabbo.Core.Messages;

namespace Xabbo.Core
{
    internal class GetGroupMembersTask : InterceptorTask<GroupMembers>
    {
        private readonly int groupId;
        private readonly int page;
        private readonly string filter;
        private readonly GroupMemberSearchType searchType;

        public GetGroupMembersTask(IInterceptor interceptor, int groupId, int page, string filter, GroupMemberSearchType searchType)
            : base(interceptor)
        {
            this.groupId = groupId;
            this.page = page;
            this.filter = filter;
            this.searchType = searchType;
        }

        protected override Task OnExecuteAsync() => SendAsync(Out.RequestGuildMembers, groupId, page, filter, (int)searchType);

        [InterceptIn("GuildMembers")]
        private void OnGuildMember(InterceptEventArgs e)
        {
            try
            {
                var groupMembers = GroupMembers.Parse(e.Packet);
                if (groupMembers.GroupId == groupId &&
                    groupMembers.CurrentPage == page &&
                    groupMembers.Filter == filter &&
                    groupMembers.SearchType == searchType)
                {
                    e.Block();
                    SetResult(groupMembers);
                }
            }
            catch (Exception ex) { SetException(ex); }
        }
    }
}