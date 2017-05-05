function ii=greedy(m,prn)
ccg=cumsum(prn);
n=length(prn);
size_ccg=size(ccg);
if size_ccg(1)>size_ccg(2)
    ccg1=ccg';
else
    ccg1=ccg;
end

i1=interp1([0 ccg1],1:(n+1),rand(1,m),'linear');
ii=floor(i1);