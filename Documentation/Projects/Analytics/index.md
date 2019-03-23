STATUS
======

-   We have sketched out a number of graphs that we want implemented in
    the frontend
-   These graphs were designed by 'domain experts' and have zero UX
    input (leading to the next point)
-   We have created a static html pages at
    `cbs/Documentation/Projects/Analytics/Web Mockup` where we are
    generating the graphs using Highcharts. A couple are still missing.
    We chose to create this as the React frontend was not yet running
    and we didn't want this to slow down our progress.
-   We have moved a number of the graphs in the Web Mockup to the React
    frontend.
-   We have created a way of populating MongoDB with test data, see
    [documentation
    here](https://github.com/IFRCGo/cbs/tree/master/Source/Analytics#populating-the-database-with-test-data)
-   The back-end query towards MongoDB have been written for one graph
    (AgeAndSexDistributionAggregationByDateRange).
-   (2019-03-21) We have decided on which graphs/tables should be put in
    which pages. This is under the section `PAGES OF MULTIPLE GRAPHS`

What needs to be done
---------------------

In general/high priority:

-   \[HIGH PRIORITY\] Put all of the graphs in their assigned pages
    (section `PAGES OF MULTIPLE GRAPHS`)
-   We strongly suspect that these graphs should be presented in some
    sort of dashboard, but due to the lack of UX input/experience we
    have not considered how they should be displayed in a holistic
    manner. We have asked the UX team to provide us with this, and they
    will update
    [UXPin](https://preview.uxpin.com/6f7c2440d8ba5f7888d63932bbc82c4138712847#/pages/101608059/simulate/sitemap)
    with a design.

For each of the graphs described in `PAGES OF MULTIPLE GRAPHS`:

-   Add the missing charts to the Web Mockup
-   Code the frontend (move the charts from the Web Mockup to the React
    frontend)
-   Code all the backend queries to provide data to the frontend (see
    `Source\Analytics\Read\AgeAndSexDistribution\AgeAndSexDistributionAggregationByDateRange.cs`
    for reference)
-   Link the backend and the frontend (currently, the charts in the
    React frontend are generated from static data in the javascript)

In general/low priority:

-   Get 'domain experts' to provide appropriate labels for everything
    (e.g. 'number of reported alerts' instead of 'number of cases')
-   Figure out where to get the population number (today, this does not
    exist in CBS). The graphs do not account for this today.
-   \[DOWNGRADED, we are currently just using region/district/community
    from the Data Collector's registration page\] Figure out where to
    extract geographical values (district, region, village) from the GPS
    coordinates. Currently, all the generated graphs show all the data
    (national level).
-   \[DOWNGRADED\] Generate the graph based on user input (currently all
    the graphs are simply displayed on the page, the user cannot specify
    timerange, age, sex etc. to display on the graphs). A lot of the
    epicurves are actually just variants on a single graph, so in the
    future it would probably be smart to just make this 1 extremely
    dynamic graph. We are calling this the **dynamic epicurve**
    (<https://github.com/IFRCGo/cbs/issues/922>).

Suggested working order
-----------------------

1.  Look at the section `PAGES OF MULTIPLE GRAPHS`
2.  Select a page
3.  Select a graph/table on that page
4.  Make it work!

Note that `PAGE 3 - Outbreak mode, per health risk ("Analytics 13")` is
the easiest page.

PAGES OF MULTIPLE GRAPHS
========================

Here we will list the contents of various pages.

In general, we cannot show too much information at once. For example, it
is difficult to show multiple weeks of data, for multiple geographical
areas, for multiple health risks. It is much easier (and cleaner!) to
show 1 week of data, for 1 geographical area, for multiple health risks.

CLASSICAL DESCRIPTIVE STATISTICS
--------------------------------

PAGE 1 - Country overview, all health risks ("Analytics 3")
-----------------------------------------------------------

This page is designed to show an overview of the country **right now**.

We will show:

-   Fixed/limited time periods
-   Fixed/limited geographical areas
-   All of the health risks

This will be done through:

-   A table containing the number of case reports in the last 0-6, 7-13,
    14-21, 22-27 days (columns) for each health risk (rows) for the
    whole country
-   For each health risk, display a separate barchar containing the
    number of case reports per district over the last 7 days. Reference:
    `GRAPH TYPES - Barcharts by district`
-   Display the number of case reports per gender over the last 7 days.
    Total number over all health risks, whole country. Bar chart.
    Reference:
    `GRAPH TYPES - Age and sex distribution over different time frames`
-   Display the number of case reports per age group over the last 7
    days (over/under 5 years old). Total number over all health risks,
    whole country. Bar chart. Reference:
    `GRAPH TYPES - Age and sex distribution over different time frames`
-   Display each case report over the last 7 days on a map by marking
    the position on the map for the Data collector who sent the report,
    with different color for different health risks

PAGE 2 - Country overview, per health risk ("Analytics 4")
----------------------------------------------------------

This page is designed to show an overview of the country according to a
specific health risk.

We will show:

-   Multiple time periods (i.e. trend over time)
-   Fixed/limited geographical areas
-   One health risk

This will be done through:

-   Daily epicurve for last week with different colors in the bars per
    community, but only up to 5 communities. If there are case reports
    from more than 5 communities last week, display per district instead
    or just have the total over all communities. Reference:
    `GRAPH TYPES - Epicurves/Daily epicurve`
-   Weekly epicurve for last 8 weeks. Reference:
    `GRAPH TYPES - Epicurves/Weekly epicurve`
-   Display the number of case reports per gender over the last 7 days
    (bar graph). Reference:
    `GRAPH TYPES - Age and sex distribution over different time frames`
-   Display the number of case reports per age group over the last 7
    days (over/under 5 years old) (bar graph). Reference:
    `GRAPH TYPES - Age and sex distribution over different time frames`
-   Display each case report over the last 7 days on a map by marking
    the position on the map for the Data collector who sent the report,
    with different color for different health risks

PAGE 3 - Outbreak mode, per health risk ("Analytics 13")
--------------------------------------------------------

This page is designed to show weekly epicurves (according to a specific
health risk) for:

1.  every region and
2.  every district and
3.  every community that has reported in the last 4 weeks.

This is just a straight out long list of weekly epicurves (one on top of
each other, scrolling down a very long page).

We have also considered that each part could be collapsable. So, for
example, when you first open the page you would see a list of regional
epicurves. Under each regional epicurve you would then have the option
to "expand" and see the district epicurves for that region. Under each
district epicurve you would have the option to "expand" and see the
communities under that district that have reported in the last 4 weeks.

Reference: `GRAPH TYPES - Epicurves/Weekly epicurve`

INFORMATION ON DATA COLLECTORS
------------------------------

PAGE 4 - Training/reporting ("Analytics 7")
-------------------------------------------

In a table:

-   Display number of Data collectors trained in total (number of Data
    collectors currently in CBS for the national society)
-   Display how many Data collectors have been active last 7 days
    (active if case report or activity report was send by the user last
    7 days)
-   Display how many Data collectors have been active last 30 days
    (active if case report or activity report was send by the user last
    30 days)
-   Display the number of male/female Data collectors trained in total

PAGE 5 - Location and status ("Analytics 8/9")
----------------------------------------------

Please reference the section
`VOLUNTEER INFORMATION - Individual level information (complicated)` for
inspiration.

A map containing:

-   Display each Data collectors GPS position (as registered on the Data
    collectors profile information)
-   Mark each Data collectors position on the map where the mark has
    different colors based on the Data collector status:
    -   Blue if active and reporting without errors
    -   Yellow if active and reporting, but x out of y last reports were
        in error or dismissed
    -   Red if inactive (no case or activity reports sent for more than
        7 days)
-   Click the Data collectors position on the map to see Data collector
    info (linked to the table below).

In a table, for each Data collector, display:

-   Name
-   Location (Village, but call it Community)
-   Phone number
-   days since last report (case or activity report)
    ================================================

-   Weekly status over the last 8 weeks. Have a color coded
    mark/indicator per week:
    -   Blue if active and reporting without errors
    -   Yellow if active and reporting, but one or more of the reports
        that week where in error or dismissed
    -   Red if inactive (no case or activity reports sent that week)
-   Supervisors can only see Data collectors they supervise, not Data
    collectors supervised by other Supervisors. Data owner sees all

PAGE 6 - Errors ("Analytics 10")
--------------------------------

-   Display a table with Data collectors often sending reports with
    errors: If 5 of the last 10 (?) reports from a Data collector had
    errors it's displayed in this table
-   Display a table with Data collectors often sending reports that are
    being dismissed: If 5 of the last 10 (?) reports from a Data
    collector were dismissed it's displayed in this table
-   Supervisors can only see Data collectors they supervise, not Data
    collectors supervised by other Supervisors. Data owner sees all

INFORMATION ON ALERTS
---------------------

PAGE 7 - ("Analytics 11/12")
----------------------------

-   Display how many alerts have been triggered in total, how many was
    escalated and how many were dismissed

-   Display a table, where each week is a column and each community is a
    row (only display communities that have had an alert in the last 8
    weeks). Each week (cell in the table) has a color to indicate
    status:
    -   blue (no open/ongoing alert)
    -   red (at least one open/ongoing alert)
    -   black (zero open/ongoing alerts and &gt;=1 closed alerts)
-   So if fex an alert for community A was triggered in week 3 and
    closed in week 7, then week 1 and 2 is blue, 3 is red (when looking
    at the dashboard before week7) and black (when looking at the
    dashboard after week7) and weeks 4-8 are blue

-   Can click on a red/black cell and get alert details for the
    week/community (see next points)
-   See the status and health risk for the alert. Status can be Open,
    Escalated, Dismissed or Closed.
-   See all reports linked to the alert. For each report, see
    -   Date when the report was sent
    -   Location (Village)
    -   Data collector name/number
    -   Supervisor of the Data collector who sent the report
    -   Report assessment (Kept, Dismissed or Not assessed)

DEFINITIONS
===========

**Epicurve**

Epicurves is the epidemiological term for a time series graph showing
the number of reported cases on the y-axis and time on the x-axis.

Right now (codeathon 2019-01-19), we are hard coding each epicurve into
its own page. However, in the future, we will make one "Epicurve" page
that has a number of options that allows all possible/desirable
epicurves to be generated on the same page (see:
<https://github.com/IFRCGo/cbs/issues/922>).

We now demonstrate the important definitions:

**facet\_grid**

Here we have a facet\_grid with `x=age` and `y=sex`. We tend to use
facet\_grid when we have a small amount of values to facet on, and we
know how many there will be (e.g. age and sex, maybe health factor).

This is how to do it via Highcharts:
<https://www.highcharts.com/blog/post/why-and-how-to-split-one-chart-into-a-grid-of-charts-aka-small-multiple/>

![](index_files/figure-markdown_strict/unnamed-chunk-2-1.png)

**facet\_wrap**

Here we have a facet\_wrap on `sex`. We use facet\_wrap when there will
be a lot of values to facet on, and we don't know how many there will be
in advance (e.g. geography is a good one).

This is how to do it via Highcharts:
<https://www.highcharts.com/blog/post/why-and-how-to-split-one-chart-into-a-grid-of-charts-aka-small-multiple/>

![](index_files/figure-markdown_strict/unnamed-chunk-3-1.png)

**dodge**

Here we dodge on `sex`. This means we put the values side-by-side in the
same graph (and colour them differently). We dodge when there are a
small amount of values to compare against.

This is definitely possible using Highcharts.

![](index_files/figure-markdown_strict/unnamed-chunk-4-1.png)

**Dynamic options**

Geography:

Levels (this part will need to be more flexible depending on the
circumstances, but this is a good start):

-   all (i.e. all the data -- national level)
-   district
-   region
-   village

The 'geographical value' is stored in 'geo'. i.e. if `level=district`,
then maybe `geo=Western Norway`. If `level=village` then maybe
`geo=Oslo`.

`Sex` is:

-   All
-   Male
-   Female

`Age` is:

-   All
-   Age &lt;5
-   Age 5+

GRAPH TYPES - Epicurves
=======================

Weekly epicurve
---------------

Frontend issue: <https://github.com/IFRCGo/cbs/issues/845>

Backend issue: <https://github.com/IFRCGo/cbs/issues/846>

Chart in Web Template:
`cbs/Documentation/Projects/Analytics/Web Mockup/epicurvebyweek.html`

Chart in React frontend:
`cbs/Source/Analytics/Web/src/components/Epicurvebyweek.js`

Query backend for data: **NOT COMPLETED YET**

Included in dynamic epicurve
(<https://github.com/IFRCGo/cbs/issues/922>): **NOT COMPLETED YET**

Here we display a weekly `epicurve` (the epidemiological term for a time
series graph showing the number of reported cases on the y-axis and time
on the x-axis).

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed

![](index_files/figure-markdown_strict/unnamed-chunk-5-1.png)

Daily epicurve
--------------

Frontend issue: <https://github.com/IFRCGo/cbs/issues/848>

Backend issue: <https://github.com/IFRCGo/cbs/issues/849>

Chart in Web Template:
`cbs/Documentation/Projects/Analytics/Web Mockup/Epicurvebyday.html`

Chart in React frontend:
`cbs/Source/Analytics/Web/src/components/Epicurvebyday.js`

Query backend for data: **NOT COMPLETED YET**

Included in dynamic epicurve
(<https://github.com/IFRCGo/cbs/issues/922>): **NOT COMPLETED YET**

Here we display a daily `epicurve`.

Important to note:

-   Unclear the best way to display date on the x-axis
-   Days with zero cases must be displayed

![](index_files/figure-markdown_strict/unnamed-chunk-6-1.png)

Weekly epicurve dodged by age
-----------------------------

Frontend issue: <https://github.com/IFRCGo/cbs/issues/850>

Backend issue: <https://github.com/IFRCGo/cbs/issues/851>

Chart in Web Template:
`cbs/Documentation/Projects/Analytics/Web Mockup/Epicurvebyweekdodgedbyage.html`

Chart in React frontend:
`cbs/Source/Analytics/Web/src/components/Epicurvebyweekdodgedbyage.js`

Query backend for data: **NOT COMPLETED YET**

Included in dynamic epicurve
(<https://github.com/IFRCGo/cbs/issues/922>): **NOT COMPLETED YET**

Here we display a weekly `epicurve` with two columns for each week,
showing the ages side-by-side.

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed

![](index_files/figure-markdown_strict/unnamed-chunk-7-1.png)

Daily epicurve dodged by age
----------------------------

Frontend issue: <https://github.com/IFRCGo/cbs/issues/852>

Backend issue: <https://github.com/IFRCGo/cbs/issues/853>

Chart in Web Template:
`cbs/Documentation/Projects/Analytics/Web Mockup/epicurvebydaydodgedbyage.html`

Chart in React frontend: **Not generated yet**

Query backend for data: **NOT COMPLETED YET**

Included in dynamic epicurve
(<https://github.com/IFRCGo/cbs/issues/922>): **NOT COMPLETED YET**

Here we display a daily `epicurve` with two columns for each day,
showing the ages side-by-side.

Important to note:

-   Unclear the best way to display date on the x-axis
-   Days with zero cases must be displayed

![](index_files/figure-markdown_strict/unnamed-chunk-8-1.png)

Weekly epicurves facet\_grid by age/sex
---------------------------------------

Note: The current chart in Web Template has created the graph **dodged**
by age/sex, but we need it to be **facet\_grid** by age/sex. As
mentioned above, this might not be possible in Highcharts and might need
some React trickery to get it working.

Frontend issue: <https://github.com/IFRCGo/cbs/issues/856>

Backend issue: <https://github.com/IFRCGo/cbs/issues/857>

Chart in Web Template:
`cbs/Documentation/Projects/Analytics/Web Mockup/Weeklyepicurvesbyagesex.html`

Chart in React frontend: **NOT COMPLETED YET**

Query backend for data: **NOT COMPLETED YET**

Included in dynamic epicurve
(<https://github.com/IFRCGo/cbs/issues/922>): **NOT COMPLETED YET**

Here we display four weekly epicurves, one for each age/sex combination.

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed
-   Y-axis remains the same height for all panels, to allow for easy
    comparison

![](index_files/figure-markdown_strict/unnamed-chunk-9-1.png)

Weekly epicurves facet\_wrap by geographical area
-------------------------------------------------

Note: As mentioned above, **facet\_wrap** might not be possible in
Highcharts and might need some React trickery to get it working.

Frontend issue: <https://github.com/IFRCGo/cbs/issues/858>

Backend issue: <https://github.com/IFRCGo/cbs/issues/859>

Chart in Web Template: **NOT COMPLETED YET**

Chart in React frontend: **NOT COMPLETED YET**

Query backend for data: **NOT COMPLETED YET**

Included in dynamic epicurve
(<https://github.com/IFRCGo/cbs/issues/922>): **NOT COMPLETED YET**

Here we display multiple weekly epicurves, one for each geographical
area.

Important to note:

-   We should probably be able to choose the granularity of geographical
    area (region/district/village)
-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed
-   Y-axis remains the same height for all panels, to allow for easy
    comparison (this should probably be a toggle?)
-   Very important: We should also implement one version where the
    outcome is:
    `(number of reported cases)/(estimation population)*10000` (i.e.
    number of reported cases per 10.000 population).

![](index_files/figure-markdown_strict/unnamed-chunk-10-1.png)

GRAPH TYPES - Age and sex distribution over different time frames
=================================================================

Note 1: This is not an epicurve, as the x-axis is not time.

Note 2 (2019-03-21): This has been changed. We now want one barchart
that shows the age distribution, and one barchart that shows the sex
distribution.

Frontend issue: <https://github.com/IFRCGo/cbs/issues/854>

Backend issue: <https://github.com/IFRCGo/cbs/issues/855>

Chart in Web Template:
`cbs/Documentation/Projects/Analytics/Web Mockup/Ageandsexdistributionoverdifferenttimeframes.html`
(needs to be fixed according to Note 2)

Chart in React frontend:
`cbs/Source/Analytics/Web/src/components/AgeAndSexDistribution.js`
(needs to be fixed according to Note 2)

Query backend for data: **NOT COMPLETED YET**

-   We display the number of cases, split by age/sex on the x-axis
-   We need the ability to display different time frames (e.g. per week,
    last week, over multiple weeks)

![](index_files/figure-markdown_strict/unnamed-chunk-11-1.png)![](index_files/figure-markdown_strict/unnamed-chunk-11-2.png)

GRAPH TYPES - Map by geographical area
======================================

Frontend issue: <https://github.com/IFRCGo/cbs/issues/860>

Backend issue: <https://github.com/IFRCGo/cbs/issues/861>

Chart in Web Template:
`cbs/Documentation/Projects/Analytics/Web Mockup/Mapbygeographicalarea.html`

Chart in React frontend: **NOT COMPLETED YET**

Query backend for data: **NOT COMPLETED YET**

Here we display a map with categorized number of cases.

Important to note:

-   We should probably be able to choose the granularity of geographical
    area (region/district/village)
-   We should be able to change the time-frame
-   Not reporting regions should be highlighted
-   The graphing/outcome should be categorical NOT a continuous
    gradient. Probably no more than 4 categories.
-   Very important: We should also implement one version where the
    outcome is:
    `(number of reported cases)/(estimation population)*10000` (i.e.
    number of reported cases per 10.000 population).

![](index_files/figure-markdown_strict/unnamed-chunk-12-1.png)

GRAPH TYPES - Barcharts by district
===================================

Frontend issue: <https://github.com/IFRCGo/cbs/issues/862>

Backend issue: <https://github.com/IFRCGo/cbs/issues/863>

Chart in Web Template: **NOT COMPLETED YET**

Chart in React frontend: **NOT COMPLETED YET**

Query backend for data: **NOT COMPLETED YET**

This is very similar to the above map, but allows for a more nuanced
view of the numbers.

Important to note:

-   We should probably be able to choose the granularity of geographical
    area (region/district/village)
-   We should be able to change the time-frame
-   The graphing/outcome should be CONTINUOUS
-   Very important: We should also implement one version where the
    outcome is:
    `(number of reported cases)/(estimation population)*10000` (i.e.
    number of reported cases per 10.000 population).

![](index_files/figure-markdown_strict/unnamed-chunk-13-1.png)

VOLUNTEER INFORMATION
=====================

**THIS INFORMATION HAS BEEN SUPERSCEDED BY THE "PAGES OF MULTIPLE
GRAPHS" SECTION AT THE TOP OF THIS PAGE.**

The previous graphs have been about health risks. We also need
information about the volunteers.

Aggregate information (basic)
-----------------------------

**THIS INFORMATION HAS BEEN SUPERSCEDED BY THE "PAGES OF MULTIPLE
GRAPHS" SECTION AT THE TOP OF THIS PAGE.**

We require a table with each row corresponding to a particular
geographical region (granularity of geographical level will need to be
specified), and two columns:

-   How many volunteers are active
-   How many volunteers are registered

So for example, if granularity is "national" then we would expect only 1
row. If granularity is "district" then we would have 1 row per district.

Individual level information (complicated)
------------------------------------------

**THIS INFORMATION HAS BEEN SUPERSCEDED BY THE "PAGES OF MULTIPLE
GRAPHS" SECTION AT THE TOP OF THIS PAGE.**

We require a table with each row corresponding to an individual
volunteer and multiple columns:

-   Name
-   Location
-   How long they have been engaged
-   Number of days since last report
-   Has reported in the last 0-7 days? \[colored box, blue if yes, red
    if no\]
-   Has reported in the last 8-14 days? \[colored box, blue if yes, red
    if no\]
-   Has reported in the last 15-21 days? \[colored box, blue if yes, red
    if no\]
-   Has reported in the last 22-28 days? \[colored box, blue if yes, red
    if no\]
-   Has reported in the last 29-35 days? \[colored box, blue if yes, red
    if no\]
-   Has reported in the last 36-42 days? \[colored box, blue if yes, red
    if no\]

Note: The 0-7, 8-14, etc numbers are for a weekly example. There will
need to be the option to specify "daily", "weekly", or "monthly".

This table will be linked to a map where the GPS coordinates of each of
the volunteers is displayed. It will be possible to select individuals
using the map, and these selected individuals will then be highlighted
in the above table.

![](static_images/volunteer_individ.jpg)

Program statistics
------------------

Is it possible to display this information as summary program
statistics?

-   Number of volunteers
-   % of Red Cross volunteers active the last 30(XX) days
-   Number of trained volunteers / total sum of volunteers
-   Number of active volunteers the last 30 days
-   Number of Red Cross volunteers trained by moths
-   Above information displayed by Age/ sex

District/Person reporting funnel plot A
---------------------------------------

NOTE: THIS SECTION HAS BEEN DOWNGRADED IN PRIORITY. FOR THE MOMENT, DO
NOT IMPLEMENT.

Frontend issue: <https://github.com/IFRCGo/cbs/issues/869>

Backend issue: <https://github.com/IFRCGo/cbs/issues/870>

Chart in Web Template: **NOT COMPLETED YET**

Chart in React frontend: **NOT COMPLETED YET**

Query backend for data: **NOT COMPLETED YET**

The idea of this funnel plot is to identify districts/people who are
reporting worse than expected.

For each month, we count the number of messages sent, and the number of
correctly sent messages. From this, we generate an "expected proportion
of received messages that are correct" (e.g. 80%). Then, for i = 1, ...,
100 (or higher, as necessary) we calculate the 2.5th and 97.5th
percentiles according to the binomial distribution. That is, (e.g. for
i=40) what is the 2.5th and 97.5th percentile of a Binom(n=40, p=0.8)
distribution. These percentiles are our boundaries as displayed in the
graph.

Important to note:

-   We should be able to switch between district/people/other grouping
    measure
-   We should be able to change the time-frame
-   Maybe only the people/groups who are "lower than expected" should be
    highlighted in some way?

![](index_files/figure-markdown_strict/unnamed-chunk-14-1.png)

District/Person reporting funnel plot B
---------------------------------------

NOTE: THIS SECTION HAS BEEN DOWNGRADED IN PRIORITY. FOR THE MOMENT, DO
NOT IMPLEMENT.

Frontend issue: <https://github.com/IFRCGo/cbs/issues/871>

Backend issue: <https://github.com/IFRCGo/cbs/issues/872>

Chart in Web Template: **NOT COMPLETED YET**

Chart in React frontend: **NOT COMPLETED YET**

Query backend for data: **NOT COMPLETED YET**

The idea of this funnel plot is to identify districts/people who are
reporting worse than expected.

For each month, we count the number of messages sent, and the number of
correctly sent messages. From this, we generate an "expected proportion
of received messages that are correct" (e.g. 80%). Then, for each
district/person, we calculate the 2.5th and 97.5th percentiles according
to the binomial distribution. That is, (e.g. if Oslo sent 40 messages)
what is the 2.5th and 97.5th percentile of a Binom(n=40, p=0.8)
distribution. These percentiles are our boundaries as displayed in the
graph.

Important to note:

-   We should be able to switch between district/people/other grouping
    measure
-   We should be able to change the time-frame
-   Maybe only the people/groups who are "lower than expected" should be
    highlighted in some way?

<!-- -->

    ## Warning: Removed 6 rows containing missing values (geom_linerange).

    ## Warning: Removed 6 rows containing missing values (geom_linerange).

    ## Warning: Removed 6 rows containing missing values (geom_linerange).

    ## Warning: Removed 6 rows containing missing values (geom_point).

![](index_files/figure-markdown_strict/unnamed-chunk-15-1.png)
