% XX = -11:1:54;
% YY = zeros(size(XX));
% for i = 1:1:length(XX)
%     YY(i) = FitnessFcn([XX(i)]);
% end
% 
% plot(XX, YY)

startPopulation = randint(10, 1, [-10, 53])

options = gaoptimset(...
    'EliteCount', 4, ...
    'PopulationSize', 10, ...
    'InitialPopulation', startPopulation, ...
    'MutationFcn', @MutationFcn, ...
    'CrossoverFcn', @CrossoverFcn ...
);


[x,fval] = ga(@FitnessFcn, 1, options)
