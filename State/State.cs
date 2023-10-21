namespace State
{
    public enum StateType
    {
        Idle,
        Walking,
        Running,
        Jumped,
        Attacking,
        Dead
    }

    public enum TriggerType
    {
        Shoot,
        Hit,
        Die,
        Revive,
        Stop,
        Move,
        SpeedUp,
    }

    public class State
    {
        private static Dictionary<StateType, List<(TriggerType, StateType)>> _stateMap 
            = new Dictionary<StateType, List<(TriggerType, StateType)>> {
                [StateType.Idle] = new List<(TriggerType, StateType)>
                {
                    (TriggerType.Move, StateType.Walking),
                    (TriggerType.Shoot, StateType.Attacking),
                    (TriggerType.Die, StateType.Dead)
                },
                [StateType.Walking] = new List<(TriggerType, StateType)>
                {
                    (TriggerType.Stop, StateType.Idle),
                    (TriggerType.Shoot, StateType.Attacking),
                    (TriggerType.Die, StateType.Dead),
                    (TriggerType.SpeedUp, StateType.Running)
                },
                [StateType.Running] = new List<(TriggerType, StateType)>
                {
                    (TriggerType.Stop, StateType.Idle),
                    (TriggerType.Shoot, StateType.Attacking),
                    (TriggerType.Die, StateType.Dead),
                    (TriggerType.SpeedUp, StateType.Running)
                },
            };
    }
}