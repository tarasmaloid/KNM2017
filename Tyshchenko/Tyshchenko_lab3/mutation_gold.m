function gch=mutation_gold(g1,g2,cp)

for cpc=1:cp
    if g2(cpc)~=g1(cpc)
        ind = int16(double(length(g1)*0.61803));
        tmp = g1(ind+1);
        g1(ind+1)=g1(ind);
        g1(ind)=tmp; 
    end
end
gch=g1;