namespace catalogAPI.Consumer.Parameters
{
    public class ParametersModel
    {
        public ParametersModel()
        {
            BootstrapServer = "localhost:9092";
            TopicName = "topic1";
            GroupId = "user1";
        }

        public string BootstrapServer { get; set; }
        public string TopicName { get; set; }
        public string GroupId { get; set; }
    }
}
