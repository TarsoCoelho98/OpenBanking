using Newtonsoft.Json;
using OpenBanking.Data.Models;
using System.Collections.Generic;
using System.Net;

namespace OpenBanking.Services
{
    public class ParticipantService
    {
        internal readonly string truncateCommand = "TRUNCATE TABLE Participant";
        readonly string defaultColumnValue = "NULL";
        readonly string openBankingEndpoint = "https://data.directory.openbankingbrasil.org.br/participants";

        public List<Participant> GetUpdatedData()
        {
            string json = string.Empty;
            var participants = new List<Participant>();

            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(openBankingEndpoint);
                dynamic obj = JsonConvert.DeserializeObject(json);

                foreach (var element in obj)
                {
                    var name = defaultColumnValue;
                    var apiEndpoint = defaultColumnValue;
                    var logo = defaultColumnValue;

                    try
                    {
                        if (string.IsNullOrEmpty(element.OrganisationName.ToString()))
                            continue;

                        name = element.OrganisationName;
                        var firstAuthServer = element.AuthorisationServers[0];
                        try
                        {
                            apiEndpoint = firstAuthServer.ApiResources[0].ApiDiscoveryEndpoints[0].ApiEndpoint;
                        }
                        catch { }
                        logo = firstAuthServer.CustomerFriendlyLogoUri;
                    }
                    finally
                    {
                        participants.Add(new Participant() { Name = name, ApiEndpointUrl = apiEndpoint, LogoUrl = logo });
                    }
                }
            }

            return participants;
        }
    }
}
