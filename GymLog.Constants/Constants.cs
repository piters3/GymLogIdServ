namespace GymLog {

    public class GymLogConstants {

        public const string API = "http://localhost:62238/";
        public const string MVCClient = "https://localhost:44376/";

        //public const string IdSrvIssuerUri = "https://expensetrackeridsrv3/embedded";

        public const string IdSrv = "https://localhost:44321/identity";
        public const string IdSrvToken = IdSrv + "/connect/token";
        public const string IdSrvAuthorize = IdSrv + "/connect/authorize";
        public const string IdSrvUserInfo = IdSrv + "/connect/userinfo";
    }
}
