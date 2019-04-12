Epicurve by week
----------------

Here we display a weekly `epicurve` (the epidemiological term for a time
series graph showing the number of reported cases on the y-axis and time
on the x-axis).

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed

![](report_files/figure-markdown_strict/unnamed-chunk-1-1.png)

Epicurve by day
---------------

Here we display a daily `epicurve`.

Important to note:

-   Unclear the best way to display date on the x-axis
-   Days with zero cases must be displayed

![](report_files/figure-markdown_strict/unnamed-chunk-2-1.png)

Epicurve by week dodged by age
------------------------------

Here we display a weekly `epicurve` with two columns for each week,
showing the ages side-by-side.

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed

![](report_files/figure-markdown_strict/unnamed-chunk-3-1.png)

Epicurve by day dodged by age
-----------------------------

Here we display a daily `epicurve` with two columns for each day,
showing the ages side-by-side.

Important to note:

-   Unclear the best way to display date on the x-axis
-   Days with zero cases must be displayed

![](report_files/figure-markdown_strict/unnamed-chunk-4-1.png)

Age and sex distribution over different time frames
---------------------------------------------------

-   We display the number of cases, split by age/sex on the x-axis
-   We need the ability to display different time frames (e.g. per week,
    last week, over multiple weeks)

![](report_files/figure-markdown_strict/unnamed-chunk-5-1.png)

Weekly epicurves by age/sex
---------------------------

Here we display four weekly epicurves, one for each age/sex combination.

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed
-   Y-axis remains the same height for all panels, to allow for easy
    comparison

![](report_files/figure-markdown_strict/unnamed-chunk-6-1.png)

Weekly epicurves by geographical area
-------------------------------------

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

![](report_files/figure-markdown_strict/unnamed-chunk-7-1.png)

Map by geographical area
------------------------

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

![](report_files/figure-markdown_strict/unnamed-chunk-8-1.png)

Barcharts by district
---------------------

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

![](report_files/figure-markdown_strict/unnamed-chunk-9-1.png)

District/Person reporting funnel plot A
---------------------------------------

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

![](report_files/figure-markdown_strict/unnamed-chunk-10-1.png)

District/Person reporting funnel plot B
---------------------------------------

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

![](report_files/figure-markdown_strict/unnamed-chunk-11-1.png)
