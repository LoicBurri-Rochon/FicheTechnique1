# Battery Tester Branch
The battery tester aims to diagnose the portable computer (laptop) battery performance.
the test consists of registering the estimated charge remaining every 30 minutes in a text file until the test is stop or the computer shuts down.

Done:
Base implementation of the Tester (registering of battery percentage every 30 minutes in a txt file stored in the current user directory).
Opens result txt file if the test is purposefully stopped.

TO DO:
creation of a graph that shows the battery charge decay in intervals of 30 minutes.
implementation of ressource heavy task to put stress on the battery to make the test more meaningful.
