Citrix Netscaler Powershell Module
===
The Citrix Netscaler Powershell Module project is early development on a Powershell module that uses the [Citrix Netscaler .NET SDK](http://www.nuget.org/packages/CitrixNetScalerSDK/) to provide native Powershell commands to the netscaler appliance.

Requirements
-----
The Netscaler module requires the following

*  PowerShell version 3.0
* As well as .Net version 4.x [http://msdn.microsoft.com/en-us/library/5a4x27ek(v=vs.110).aspx](http://msdn.microsoft.com/en-us/library/5a4x27ek(v=vs.110).aspx)
* A Citrix Netscaler application. If you don't have one available to you, see the Additional Information section


Install
----
To install this experimental module, you will need to download the release source code and build it. Once built you should copy the files in /bin/debug directory to a directory you specify on you local computer.

Once you have the binary files copied you should run the following command in powershell
Import-Module [your local directory]\NetscalerPSCmdlets.dll

Once you have the module loaded you can issue the powershell commands.
ex: Get-NSIP ...


License
----
All code is licensed under the [MIT
License](https://github.com/citrix/Netscaler-Powershell-Module/blob/master/License.txt).

Additional Information
--------
If you would like to develop for the Citrix Netscaler platform, you can obtain the express virtual appliance along with a license on the Citrix Download site. The direct download link is [here](https://www.citrix.com/downloads/netscaler-adc/virtual-appliances/netscaler-vpx-express.html).

* This download requires you to have a Citrix account, which you can obtain for free from the [Citrix Developer](http://www.citrix.com/go/citrix-developer/citrix-developer-signup.html) site.
