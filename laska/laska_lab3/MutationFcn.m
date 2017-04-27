function [  mutationChildren ] = MutationFcn( parents, options, nvars, ...
FitnessFcn, state, thisScore, thisPopulation )
% Проводить мутацію методом золотого січення

% parents - номер особини в популяції, що мутує
% nvars - кількість змінних
% state - інформація про поточну популяцію
% thisScore - оцінки поточної популяції
% thisPopulation - поточна популяція

 k = 0.62;              % k=62%
 t = ceil(k*nvars);     % точка розриву

 mutant = thisPopulation(parents, :);
 v1 = mutant(1:t);
 v2 = mutant(t+1:nvars);

 mutationChildren = [v2, v1];
 
end

