using System;
using System.Collections;
using System.Threading.Tasks;
using Asyncoroutine;
using Services;
using SystemTime;

namespace Game.App
{
    public sealed class RealtimeClockStarter
    {
        [ServiceInject]
        private RealtimeClock realtimeClock;

        [ServiceInject]
        private RealtimePreferences preferences;
        
        public async Task StartClockAsync()
        {
            if (this.preferences.LoadData(out RealtimeData previousSession))
            {
                await this.StartByPrevious(previousSession.nowSeconds);
            }
            else
            {
                await this.StartAsFirst();
            }
        }

        private IEnumerator StartByPrevious(long previousSeconds)
        {
            yield return OnlineTime.RequestNowSeconds(nowSeconds =>
            {
                var pauseTime = Math.Max(nowSeconds - previousSeconds, 0);
                this.realtimeClock.Play(nowSeconds, pauseTime);
            });
        }

        private IEnumerator StartAsFirst()
        {
            yield return OnlineTime.RequestNowSeconds(nowSeconds =>
            {
                this.realtimeClock.Play(nowSeconds);
            });
        }
    }
}