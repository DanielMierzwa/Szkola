x=-1
marks=[]
sum=0
min=7
max=0
positive=0
while x!=0:
    x=int(input("Podaj ocenę(lub zero żeby zakończyć i przejść do podsumowania): "))
    if x==0:
        continue
    sum+=x
    if(x>max):
        max=x
    if(x<min):
        min=x
    if(x>=3):
        positive+=1
    marks.append(x)
print("Średnia: "+str(sum/len(marks))+"\nOcen pozytywnych: "+str(positive)+"\nMin: "+str(min)+"\nMax: "+str(max))