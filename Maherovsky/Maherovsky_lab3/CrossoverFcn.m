function [xoverKids] = CrossoverFcn( parents, options, nvars, FitnessFcn, ...
    unused,thisPopulation )

ret = zeros(length(parents)/2, nvars);

for i = 1:2:length(parents)-1
    p1 = thisPopulation(parents(i), :);
    p2 = thisPopulation(parents(i+1), :);

    index = randi(nvars);
    child = zeros(1,nvars);
    
    point1_1=0;
    point1_2=0;    
    point2_1=0;
    point2_2=0;
      
    child(1,1)=p1(index);
    
    for j = 2:1:nvars       
         point1_1=p1(index);
         if index==5
             index=0;
         end;
         
         point2_1=findAppropriateCoord(p1,child,point1_1,index);
         
         indexOfElem=find(p2==point1_1);       
         point1_2=p2(indexOfElem);         
         if indexOfElem==5
             indexOfElem=0;
         end;
         
         point2_2=findAppropriateCoord(p2,child,point1_2,indexOfElem);
                  
         dist1=findDistance(point1_1,point2_1);
         dist2=findDistance(point1_2,point2_2);
         
         if(dist1<=dist2)
             child(1,j)=point2_1;
             index=find(p1==point2_1);
         else
             child(1,j)=point2_2;
             index=find(p1==point2_2);
         end;
         
    end;
    ret((i+1)/2,:) = child;    
end;

xoverKids = ret;

end