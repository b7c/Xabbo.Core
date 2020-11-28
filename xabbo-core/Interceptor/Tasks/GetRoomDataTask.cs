﻿using System;
using System.Threading.Tasks;

using Xabbo.Core.Messages;

namespace Xabbo.Core.Tasks
{
    [RequiredOut(nameof(Outgoing.RequestRoomData))]
    public class GetRoomDataTask : InterceptorTask<IRoomData>
    {
        private readonly int roomId;

        public GetRoomDataTask(IInterceptor interceptor, int roomId)
            : base(interceptor)
        {
            this.roomId = roomId;
        }

        protected override Task OnExecuteAsync() => SendAsync(Out.RequestRoomData, roomId, 0, 0);

        [InterceptIn(nameof(Incoming.RoomData))]
        protected void OnRoomData(InterceptArgs e)
        {
            try
            {
                var roomData = RoomData.Parse(e.Packet);
                if (roomData.Id == roomId)
                {
                    if (SetResult(roomData))
                        e.Block();
                }
            }
            catch (Exception ex) { SetException(ex); }
        }
    }
}
