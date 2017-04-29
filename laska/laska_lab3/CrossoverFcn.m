function [xoverKids] = CrossoverFcn( parents, options, nvars, FitnessFcn, ...
    unused,thisPopulation )
%% Реалізація функції для схрещування потомків (циклове схрещування)

% parents - індекси батьків в поточній популяції, що беруть участь у
%           схрещуванні. вектор з парною кількістю елементів
% nvars   - кількість змінних (генів)
% unused  - вектор-стовбець із оцінкою кожної особини
% thisPopulation - поточна популяція (матриця)

ret = zeros(length(parents)/2, nvars);

for i = 1:2:length(parents) 
    p1 = thisPopulation(i, :);
    p2 = thisPopulation(i+1, :);
    
    % генеруємо цикл
    t = randi(nvars);     % початок циклу (індекс)
    cycle = zeros(nvars);
    for j = 1:1:nvars  
        cycle(j) = p1(t);
        nv = p2(t);
        t = find(p1==nv);
        if (cycle(1) == nv) 
            break;  % цикл замкнувся
        end;
    end;
    
    % елементи, що не попали в цикл успадковуються від іншого батька
    c1 = p1; c2 = p2;  
    for j = 1:1:nvars
        if (cycle(j) == 0)
            c1(j) = p2(j);
            c2(j) = p1(j);
        end;
    end;
    
    ret((i+1)/2,:) = c1;  
end;

xoverKids = ret;

end

