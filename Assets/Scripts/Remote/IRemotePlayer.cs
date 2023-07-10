namespace VFSCloud
{
    public interface IRemotePlayer
    { 
        public void LoadConfigs(PlayerData theData);
    }
    public interface IRemotePlatforms
    {
        public void LoadConfigs(PlatformData theData);
    }
}

