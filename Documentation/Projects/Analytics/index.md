STATUS
======

Codeathon 2019-01-19

Codeathon 2018-09

IMPORTANT NOTES ON EPICURVES
============================

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

![](index_files/figure-markdown_strict/unnamed-chunk-2-1.png)

**facet\_wrap**

Here we have a facet\_wrap on `sex`. We use facet\_wrap when there will
be a lot of values to facet on, and we don't know how many there will be
in advance (e.g. geography is a good one)

![](index_files/figure-markdown_strict/unnamed-chunk-3-1.png)

**dodge**

Here we dodge on `sex`. This means we put the values side-by-side in the
same graph (and colour them differently). We dodge when there are a
small amount of values to compare against.

![](index_files/figure-markdown_strict/unnamed-chunk-4-1.png)

Epicurve by week
----------------

Please note that in principle, this will be superseded by:
<https://github.com/IFRCGo/cbs/issues/922> (also see the top of this
document: `IMPORTANT NOTES ON EPICURVES`).

Here we display a weekly `epicurve` (the epidemiological term for a time
series graph showing the number of reported cases on the y-axis and time
on the x-axis).

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed

![](index_files/figure-markdown_strict/unnamed-chunk-5-1.png)

Epicurve by day
---------------

Please note that in principle, this will be superseded by:
<https://github.com/IFRCGo/cbs/issues/922> (also see the top of this
document: `IMPORTANT NOTES ON EPICURVES`).

Here we display a daily `epicurve`.

Important to note:

-   Unclear the best way to display date on the x-axis
-   Days with zero cases must be displayed

![](index_files/figure-markdown_strict/unnamed-chunk-6-1.png)

Epicurve by week dodged by age
------------------------------

Please note that in principle, this will be superseded by:
<https://github.com/IFRCGo/cbs/issues/922> (also see the top of this
document: `IMPORTANT NOTES ON EPICURVES`).

Here we display a weekly `epicurve` with two columns for each week,
showing the ages side-by-side.

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed

![](index_files/figure-markdown_strict/unnamed-chunk-7-1.png)

Epicurve by day dodged by age
-----------------------------

Please note that in principle, this will be superseded by:
<https://github.com/IFRCGo/cbs/issues/922> (also see the top of this
document: `IMPORTANT NOTES ON EPICURVES`).

Here we display a daily `epicurve` with two columns for each day,
showing the ages side-by-side.

Important to note:

-   Unclear the best way to display date on the x-axis
-   Days with zero cases must be displayed

![](index_files/figure-markdown_strict/unnamed-chunk-8-1.png)

Weekly epicurves by age/sex
---------------------------

Please note that in principle, this will be superseded by:
<https://github.com/IFRCGo/cbs/issues/922> (also see the top of this
document: `IMPORTANT NOTES ON EPICURVES`).

Here we display four weekly epicurves, one for each age/sex combination.

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed
-   Y-axis remains the same height for all panels, to allow for easy
    comparison

![](index_files/figure-markdown_strict/unnamed-chunk-9-1.png)

Weekly epicurves by geographical area
-------------------------------------

Please note that in principle, this will be superseded by:
<https://github.com/IFRCGo/cbs/issues/922> (also see the top of this
document: `IMPORTANT NOTES ON EPICURVES`).

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

Age and sex distribution over different time frames
---------------------------------------------------

Please note that in principle, this will be superseded by:
<https://github.com/IFRCGo/cbs/issues/922> (also see the top of this
document: `IMPORTANT NOTES ON EPICURVES`).

-   We display the number of cases, split by age/sex on the x-axis
-   We need the ability to display different time frames (e.g. per week,
    last week, over multiple weeks)

![](index_files/figure-markdown_strict/unnamed-chunk-11-1.png)

Map by geographical area
========================

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

Barcharts by district
=====================

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

District/Person reporting funnel plot A
---------------------------------------

NOTE: THIS SECTION HAS BEEN DOWNGRADED. FOR THE MOMENT, DO NOT
IMPLEMENT.

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

NOTE: THIS SECTION HAS BEEN DOWNGRADED. FOR THE MOMENT, DO NOT
IMPLEMENT.

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

    ## Warning: Removed 3 rows containing missing values (geom_linerange).

    ## Warning: Removed 3 rows containing missing values (geom_linerange).

    ## Warning: Removed 3 rows containing missing values (geom_linerange).

    ## Warning: Removed 3 rows containing missing values (geom_point).

![](index_files/figure-markdown_strict/unnamed-chunk-15-1.png)
