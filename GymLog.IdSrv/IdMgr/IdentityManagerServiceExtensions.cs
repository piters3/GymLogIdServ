using GymLog.Data;
using GymLog.Data.Entities;
using IdentityManager;
using IdentityManager.AspNetIdentity;
using IdentityManager.Configuration;

namespace GymLog.IdSrv.IdMgr {
    public static class IdentityManagerServiceExtensions {
        public static void ConfigureSimpleIdentityManagerService(this IdentityManagerServiceFactory factory, string connectionString) {
            factory.Register(new Registration<GymLogContext>(resolver => new GymLogContext()));
            factory.Register(new Registration<UserStore>());
            factory.Register(new Registration<RoleStore>());
            factory.Register(new Registration<UserManager>());
            factory.Register(new Registration<RoleManager>());
            factory.IdentityManagerService = new Registration<IIdentityManagerService, IdentityManagerService>();
        }
    }

    public class IdentityManagerService : AspNetIdentityManagerService<User, string, Role, string> {
        public IdentityManagerService(UserManager userMgr, RoleManager roleMgr)
            : base(userMgr, roleMgr) {
        }
    }
}