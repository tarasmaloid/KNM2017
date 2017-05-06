function distance=findDistance(point1,point2)

M = 1000;
graph = [ 
    M,  6,  4,  8,  7;
    6,  M,  7,  11, 7;
    4,  7,  M,  4,  3;
    8, 11,  7,  M,  5;
    7,  7,  3,  5,  M
];

distance=graph(point1,point2);

end