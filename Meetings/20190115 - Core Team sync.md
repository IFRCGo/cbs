Present:
Alex
Jakob
Richard
Petri
Sindre
Hodo
Bjørn
Karoline
Samson
Anine
Rebecca

* Alerts –Nothing happened since last codeathon – easy to pick up. Samson: from a requirements perspective we have made progress from the Red Cross. To be shared at codeathon. Few changes, but written out in a better way, more detailed.
* Jakob – old BCs now up and running, multiple tenants set up, communications working between BCs
* Andrei has made progress with the translation to react. Einar has a concern that the angular we had was stable and he would like to have a working react before the codeathon. The react merge is working as of today. Each BC has it’s own react frontend with publishing to MTM with navigation to backend through its own bounded context. This will need testing and discussion during codeathon. 
* Front end to react migration: an entire group should be put on this for codeathon? Einar can lead this group. A big task force is needed to finish the front end stuff. Hodo can also join this. One group for all of the DCs and one for front end? This also gives designers a space. 18 people ticket for front end, but a lot of them have also ticked for back end meaning that it is difficult to know what they prefer. 5 “only” front end. They can all go into one group. 
* Analytics will have four roles which we would like to design a page for during codeathon. To be discussed with domain experts on Thursday. To be discussed if we want a public mode (which is anonymized) – to be discussed at codeathon. Break out session with IFRC and WHO on data sharing will be a good arena for this. 
* User management will be incorporated into reporting part during the codeathon. Hoping to have feedback loop in place after codeathon. /notifications at the end of the URL will show that events between the bounded context works (direct SMS outside of notification gateway), albeit in a different shape and form than we might want it, but this is easy to change. 
* Samson to focus on admin. A discussion will be how we organize admin as it has so many components, particularly in regards to tenants. 
* Notification gateway will be worked on by Knut, a delegate who is visiting the project for two weeks. He will look at both hardware and documentation. 
* Discussion: there shouldn’t be as much code in the repository that is not production code as there is now. The stuff that is in the main repository should be what is in production (not stuff that will be removed later). Maybe this requires that we are stricter – perhaps that two people review PRs before they are merged (as of now nothing happens when pull requests are submitted). These basic rules can be decided upon as a group. To be discussed further after codeathon.  
* Analytics – should have a technical person in the team since Richard is unavailable after 10 am on Friday. Jonathan (WHO) could take same of the role (epi/statistician) and Sindre could assist with the other part, although he may be working with Dolittle questions at times. There is a lot of good documentation, so should be OK to get the team up to speed on needs. Fake data needs to be reproduced in the backend. Richard will write out some more documentation to make it obvious where everything is.   
* Discussion: can we use Richard’s documentation as an example for documenting after the codeathon? (where we stand, where we are going etc) Last codeathon didn’t really document what was done, making it difficult to follow. Spending the last hour at codeathon writing out the status and future plans is a good step. 
* Karoline still working on the getting started documentation prior to codeathon. Backend is moved, which needs documenting + react specific documentation needed. Andrei to help Karoline with this. The getting started guide doesn’t mention DoLittle at all. Useful tools section with DoLittle tools would be a good idea for participants to know where to find things + a short paragraph on the fact that CBS is built on DoLittle. Also wants to run all BCs locally (Samson tested some already and will post on slack which ones are working on mac). Karoline will test on windows on Thursday evening and notify. 
* Unit tests are only present in admin. We should test the behavior of the system – perhaps using guidelines like the ones which DoLittle use. If you do tests it is easier for others to follow. However, an issue is that there are a lot of developers who don’t know how to do unit tests. If Sindre writes some of the tests, it makes it easier for others to write tests. We can’t force people to write tests, but we should encourage everyone to do so (good coding etiquettes). Karoline can mention in her codeathon guideline introduction. 
* Core team to come at 08:00. Registration to open at 08:15. Event has to start at 09:00 as Astrup is coming. 
