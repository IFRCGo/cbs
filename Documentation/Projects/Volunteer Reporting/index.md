---
title: 
description: 
keywords: 
author: molokai
---
# Volunteer Reporting

The volunteer reporting bounded context is responsible for processing all incoming text messages from Data Collectors in the field.

In V1, registered Data Collectors submit Case Reports via SMS messaging in predefined formats. Those reports are parsed and passed on to the rest of the CBS solution, particularly to the Alerts bounded context for aggregation and processing.

Feedback is provided to the Data Collector.

The module also supports manual sending of SMS messages to Data Collectors, with a web UI for the sending, as well as customization of the SMS messages sent as feedback to the user.

# User stories

## Data Collector

* Known Data collector sends in valid single case report
* Known Data collector sends in valid aggregate case report
* Known Data collector sends in valid Zero report

* Known Data collector sends in invalid SMS message
* Known Data collector sends in 5 invalid SMS messages
* Known Data collector sends in two identical SMS messages with same time stamp

* Known Deactivated Data collector sends in valid case report

* Unknown sends in valid single/aggregate/zero case report
* Unknown sends in invalid SMS message


## Data Manager
* Send Manual SMS message to individuals
* Send Manual SMS message to [some other region / multiple regions ??]
* View / Customize content of SMS message types
	Case Report feedback to Data Collector  (includes details of report + key message)
	Zero Report feedback to Data Collector (multiple messages, send random version)
	Unknown Case report submitter - inform they must be registered
	Deactivated DataCollector Case report submitted - feedback to get reactivated
	Deactivated DataCollector Case report submitted - feedback to superviser
	Multiple invalid submissions - feedback to sender
    Multiple invalid submissions - feedback to supervisor


