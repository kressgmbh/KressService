using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FG14Connect;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KressService
{
    public class mongodb
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        string dbConnectionStringURL = "ds119736.mlab.com:19736/appharbor_xbngsdnl";
        string dbConnectionUser = "appharbor_xbngsdnl";
        string dbConnectionPassword = "Biebergemünd2";
       

        public mongodb()
        {
            string dbConURL = "mongodb://appharbor_xbngsdnl:8ir3sc2q581odao6bp4bmm480o"+ "@" + dbConnectionStringURL;
            _client = new MongoClient(new MongoUrl(dbConURL));
            _database = _client.GetDatabase("appharbor_xbngsdnl");

         
            var fg14db = _database.GetCollection<FG14v3.Systemdaten>("fg14");
        
            FG14Connect.FG14v3.Systemdaten testdaten = new FG14Connect.FG14v3.Systemdaten();
            testdaten.ID = 1;
            testdaten.Text = "TEST";
            testdaten.timestamp = DateTime.Now;
            testdaten.ToolNr = "0815";
            testdaten.User = "Kling";
            fg14db.InsertOneAsync(testdaten).Wait();
           // AddFG14SystemdatenAsync(testdaten, "Test").Wait();
        }

        public async System.Threading.Tasks.Task AddFG14ProzessdataAsync(FG14Connect.FG14v3.Prozessdaten p,string sender)
        {
            string dbConURL = "mongodb://appharbor_xbngsdnl:8ir3sc2q581odao6bp4bmm480o" + "@" + dbConnectionStringURL;
            _client = new MongoClient(new MongoUrl(dbConURL));
            _database = _client.GetDatabase("appharbor_xbngsdnl");


            var fg14db = _database.GetCollection<FG14v3.Systemdaten>("fg14");

            FG14Connect.FG14v3.Systemdaten testdaten = new FG14Connect.FG14v3.Systemdaten();
            var fg14db = _database.GetCollection<FG14v3.Prozessdaten>("fg14");

            //var document = new BsonDocument
            //    {
            //      {"Timestanp",new BsonDateTime(DateTime.Now)},
            //      {"Sender",new BsonString(sender)},
            //      {"Type",new BsonString(DsType.Prozessdaten.ToString()) },
            //      {"ZeitGesammt",(p.ZeitMontage.TotalSeconds)},
            //      {"ZeitMontage", new BsonDouble(p.ZeitMontage.TotalSeconds)},
            //      { "MaxKraft_Vorweiten", new BsonInt32(p.MaxKraft_Vorweiten)  },
            //      { "MaxKraft_Einschub", new BsonInt32(p.MaxKraft_Einschub) },
            //      { "V_Einschub",  new BsonInt32(p.MaxKraft_Einschub) },
            //      { "V_Vorweiten",  new BsonInt32(p.V_Vorweiten) },
            //      { "Einschubtiefe",  new BsonInt32(p.Einschubtiefe)  },
            //      { "Vorweittiefe",  new BsonInt32(p.Vorweittiefe)  },
            //      { "Rohrlänge", new BsonInt32(p.Rohrlänge)  },
            //      { "Leitungsname",  new BsonString(p.Leitungsname)}
            //    };
            await fg14db.InsertOneAsync(p);
          

        }

       
        public async System.Threading.Tasks.Task AddFG14SystemdatenAsync(FG14Connect.FG14v3.Systemdaten s, string sender)
        {

            //  var collectionFG14 = _database.GetCollection<BsonDocument>("fg14");
            string dbConURL = "mongodb://appharbor_xbngsdnl:8ir3sc2q581odao6bp4bmm480o" + "@" + dbConnectionStringURL;
            _client = new MongoClient(new MongoUrl(dbConURL));
            _database = _client.GetDatabase("appharbor_xbngsdnl");


            var fg14db = _database.GetCollection<FG14v3.Systemdaten>("fg14");

            FG14Connect.FG14v3.Systemdaten testdaten = new FG14Connect.FG14v3.Systemdaten();
            var fg14db = _database.GetCollection<FG14v3.Systemdaten>("fg14");

            //var document = new BsonDocument
            //    {
            //      {"Timestanp",new BsonDateTime(DateTime.Now)},
            //      {"Sender",new BsonString(sender)},
            //      {"Type",new BsonString(DsType.Prozessdaten.ToString()) },
            //      {"Timestamp",new BsonDateTime(s.timestamp)},
            //      {"User",new BsonString(s.User)},
            //      {"ID",new BsonInt32(s.ID)},
            //      {"Test",new BsonString(s.Text)},
            //      {"Tool",new BsonString(s.ToolNr)}

            //    };
            await fg14db.InsertOneAsync(s);
            //collectionFG14.InsertOneAsync(document).Wait();

        }

        enum DsType
        {
            Info =0,
            Prozessdaten =1,
            Systemdaten =2
        }

    }
}