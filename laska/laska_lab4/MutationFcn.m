function [ mutationChildren ] = MutationFcn( parents, options, nvars, ...
FitnessFcn, state, thisScore, thisPopulation )
% parents - номер особини в популяції, що мутує
% nvars - кількість змінних
% state - інформація про поточну популяцію
% thisScore - оцінки поточної популяції
% thisPopulation - поточна популяція

% маска мутації. змінює випадковий біт числа на протилежний
 mask = de2bi(1, 6);  
 mask = bitshift(mask, randi(6));
 
 mutant = thisPopulation(parents, :)+10;
 for i=1:1:nvars
    dm = de2bi(mutant(i));
    dm = dm(1:6);          %відтинаємо лишні біти
    dm = bitxor(dm, mask);
    mutant(i) = bi2de(dm)-10;
 end
 
 mutationChildren = mutant;
end

