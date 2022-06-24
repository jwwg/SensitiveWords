Sensitive Words
----------------

You are working for a start up company which would like to provide an additional piece of functionality to their clients. The 
definition of this service would be to “bloop” out sensitive words of the company’s choice, on their chat system i.e., SQL 
sensitive words, profanity, or anything the company deems “Sensitive”. As an example, we have chosen our words to be in line 
with SQL key words. An example of this would be “SELECT” or “DROP” but could be any other word on the companies Sensitive 
list.



Endpoints
---------
Internal CRUD layer lives at : WordManagementController
External SensitiveWords API lives at : SensitiveWordsController

Notes
----------
- Internal and External should be separate appplications
- Minimal error handling
- No logging
 


