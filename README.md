========
## Percolation
========

Given a composite system consisting of randomly distributed insulating and metallic materials, what proportion of the materials should be metallic for the composite system to be an electrical conductor? To model such situations, an abstract process known as percolation was defined.

## Model

In this problem, we model a percolation system using an n by n matrix. Each cell of the matrix is either open or blocked. A complete cell is an open cell that is connected to the open cell in the top row through a chain of adjacent (left, right, up, down) open cells. The system is a conductor if there is a full cell in the bottom row. 

## Indexes 

Rows: 1 <= i <= n, Columns: 1 <= j <= n

## Performance requirements

The initialization method should be executed in time proportional to O(n^2); all methods should be executed in a constant time + a constant number of calls to union() and find().