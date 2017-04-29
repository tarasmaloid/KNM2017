function main()
XX = -11:1:54;
YY = zeros(size(XX));
for i = 1:1:length(XX)
    YY(i) = FitnessFcn([XX(i)]);
end

plot(XX, YY)

startPopulation = randint(10, 1, [-10, 53]);
disp('#Пошук мінімуму');
myGa(startPopulation, @FitnessFcn);
disp('#Пошук максимуму');
myGa(startPopulation, @MaxFitnessFcn)

end

function myGa(startPopulation, func)

options = gaoptimset(...
    'EliteCount', 4, ...
    'PopulationSize', 10, ...
    'InitialPopulation', startPopulation, ...
    'MutationFcn', @MutationFcn, ...
    'CrossoverFcn', @CrossoverFcn, ...
    'OutputFcns', {@OutputFcn} ...
);

global RET;
RET = struct('generation', 0, 'population', struct, 'fvals', struct);

[x,fval,exitflag,output,population,scores] = ga(func, 1, options);

% Вивід результатів

disp('Початкова популяція:');
PrintIter(RET.population.s0, RET.fvals.s0, 1, 5);
disp('Покоління 1:');
PrintIter(RET.population.s1, RET.fvals.s1, 1, 5);
disp('Покоління 2:');
PrintIter(RET.population.s2, RET.fvals.s2, 1, 5);

disp('Результат:');
PrintIter(population, scores, 1, 5);
fprintf('f(%d) = %d\n\n', x, fval); 
end

function PrintIter(curp, fval, nvars, psize)
    % функція для виводу популяції 
    for i = 1:1:psize
        fprintf('[');
        for j=1:1:nvars
            fprintf('%3d ', curp(i,j));
        end;
        fprintf(']=>%d\t', fval(i));
    end;
    fprintf('\n');
end
