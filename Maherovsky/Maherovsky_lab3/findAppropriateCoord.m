function point2=findAppropriateCoord(parentArray,child,point1,index)
    if ~ismember(parentArray(index+1),child)
              point2=parentArray(index+1);
         else
             minValue=1000;
             minIndex=0;
             for k=1:1:length(child)
                 if ~ismember(parentArray(k),child) && parentArray(k) ~= point1
                     dist=findDistance(point1,parentArray(k));
                     if dist<minValue
                         minValue=dist;
                         minIndex=k;
                     end;
                 end;
             end;
             
             point2=parentArray(minIndex);
         end;
end