# CachingChallenge

GOAL

Create an in-memory data cache for the
SimulatedPersonListLookup method so that after the
first time you ask for data, you get data from your
cache instead of the simulated database.

BONUS

Cache the results of calls to the SimulatedPersonById
and SimulatedPersonListByLastName calls. Do not do
the queries yourself on the full list. Cache each call so
that the first time, it hits the database and then after
that it hits the cache.
