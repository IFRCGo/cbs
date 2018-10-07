Introduction
------------

This bounded context is supposed to be a "high level explanation of what
is happening on the ground". Think along the lines of national
societies.

The overriding questions that we want to answer are:

-   Who (...is sick - male/female, children/adults?)
-   What (...are the illnesses of most concern)
-   Where (...are people getting sick)
-   When (is the danger starting/increasing/decreasing/over?)

Project view
------------

In theory this should be located here, but it is out of date

<https://github.com/IFRCGo/cbs/projects/5>

Technology
----------

It has been decided that React will be used for the frontend, and D3
will be used to create the graphs/dashboards.

The React frontend is prototyped by `VolunteerReporting` and we just copy what they do.

Fake data (.xlsx, .json) and R
-----------------

`cbs/Documentation/Projects/Analytics/fakedata` contains `report.Rmd` that reads in the fake data (data/*.xlsx) and produces a number of graphs that we want to be included in the cbs system. If you like R, you can use this `report.Rmd` file to prototype and test out new possible graphs. We also plan on using this `.Rmd` file as an easy way to produce fake .json data that will be stored at `cbs/Source/Analytics/Web.React/src/assets/data/` and used for prototyping the D3 graphs.

What has been done
------

- We have sketched out a number of graphs that we want implemented in the frontend
- These graphs were designed by 'domain experts' and have zero UX input (leading to the next point)
- Fake data (.json) is provided at `cbs/Source/Analytics/Web.React/src/assets/data` for some of these graphs
- The back-end queries have been written for one graph, but we can't get it to work

What needs to be done
----------------

- We strongly suspect that these graphs should be presented in some sort of dashboard, but due to the lack of UX input/experience we have not considered how they should be displayed in a holistic manner
- Code all the back end queries to provide data to the front-end
- Code the front end
- Link the back and the front end


Epicurve by week
----------------

Here we display a weekly `epicurve` (the epidemiological term for a time
series graph showing the number of reported cases on the y-axis and time
on the x-axis).

Important to note:

-   We display `year-isoweek` on the x-axis
-   Weeks with zero cases must be displayed

![](report_files/figure-markdown_strict/unnamed-chunk-1-1.png)


There is fake json data available at `cbs/Source/Analytics/Web.React/src/assets/data/epicurve_by_week.json`.

We have also implemented a back-end query to provide data for this, but it does not work. 

We also tried to implement a simple D3 graph as a skeleton example for linking the back and front end (`cbs/Source/Analytics/Web.React/src/components/Epicurve.js`) but this has not been completed as we couldn't get the back-end query to work.

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
