---
title: Known Data collector sends in valid aggregate case report
description: Simple scenario aggregate case report submission
keywords: 
author: molokai
---
# Summary
Data collector sends SMS in correct format  
     *keyword* *health_risk_id*#*count_of_cases_male_under_5*#*count_of_cases_male_over_5*#*count_of_cases_female_under_5*#*count_of_cases_female_over_5*

  to the sms gateway

The message is processed, feedback given to the DataCollector and a CaseReportReceived event is emitted to the system.

# Prerequisites
A project exists with defined Health risks
Data collector is registered with phone number 

# Details
The SMS message is stored in the bounded context, parsed and validated. Health risk GUID looked up from 
The Data Collector receives "Case Report feedback to Data Collector" sms
		"Thank you for your submission of 4 cases of Cholera. *Key Message*"
CaseReportReceived event is raised, and the CaseReport is persisted.
