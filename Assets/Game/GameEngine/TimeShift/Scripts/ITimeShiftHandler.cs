namespace Game.GameEngine
{
    public interface ITimeShiftHandler
    {
        void OnTimeShifted(TimeShiftReason reason, float shiftSeconds);
    }
}