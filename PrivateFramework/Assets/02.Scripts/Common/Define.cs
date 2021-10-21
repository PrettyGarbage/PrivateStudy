namespace Assets._02.Scripts.Common
{
    public class Define
    {
        /// <summary>
        /// State Type
        /// </summary>
        public enum StateStatus
        {
            None,
            Initialize,
            Ready,
            OpenState,
            CloseState,
        }
        
        /// <summary>
        /// Sound Type
        /// </summary>
        public enum Sound
        {
            Bgm,
            Effect,
            MaxCount,
        }
    }
}