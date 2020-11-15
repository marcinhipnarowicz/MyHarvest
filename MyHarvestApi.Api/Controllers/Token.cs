//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.IdentityModel.Tokens;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MyHarvestApi.Api.Controllers
//{
//    public class Token : SecurityToken
//    {
//        private DateTime effectiveTime = DateTime.UtcNow;
//        private TimeSpan expirationTime = new TimeSpan(0, 24, 0, 0);
//        private string id;
//        private ReadOnlyCollection<SecurityKey> securityKeys;

//        public Token()
//        {
//            string token = "strongToken";
//        }

//        public override ReadOnlyCollection<SecurityKey> SecurityKeys
//        {
//            get { return this.securityKeys; }
//        }

//        public override DateTime ValidFrom
//        {
//            get { return this.effectiveTime; }
//        }

//        public override DateTime ValidTo
//        {
//            get
//            {
//                var datatime = effectiveTime + expirationTime;
//                return datatime;
//            }
//        }

//        public override string Id
//        {
//            get { return this.id; }
//        }
//    }
//}