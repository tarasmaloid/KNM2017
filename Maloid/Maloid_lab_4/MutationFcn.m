%% ������� ������������ �� ������

function [  mutationChildren ] = MutationFcn( parents, options, nvars, ...
    FitnessFcn, state, thisScore, thisPopulation )

% parents - ����� ������� � ���������, �� ����
% nvars - ������� ������
% thisPopulation - ������� ���������

mutant = thisPopulation(parents, :);               %�������, �� ����
offset = randi(nvars);                             %���������� ���� �������
mutationChildren = circshift(mutant',offset)';       % ������� ������ �� ����

end

%% ʳ����
