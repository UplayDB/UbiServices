# UbiServices
Gathering Information from public-ubiservices.ubi, store.ubi, etc.

### Version

Current version description is:

Year.Month.Day.Revision


### Connecting Uplay with Steam
use Steamworks. (Facepunch)
and make calls like this with Steamworks:
```cs
SteamClient.Init(359550); //siege app id, use what you own on steam (and also must have to be connected to uplay)
var res = SteamUser.RequestEncryptedAppTicketAsync().Result;
//login with this: (Convert.ToBase64String(res));
SteamClient.Shutdown();
```
You must logged in your uplay account to call UbiServices.Public.V2.ConnectSteam.
