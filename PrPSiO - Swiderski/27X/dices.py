import random

n=int(input("Podaj liczbę rzutów: "))
rands=[]
counters=[0,0,0,0,0,0]
for x in range(0,n):
    rands.append(random.randint(1,6))
    print(rands[x], end=",")
    counters[rands[x]-1]+=1
print("\n")
max=counters[0]
maxIndex=0
for i in range(len(counters)):
    print(str(i+1)+" wyrzucono "+str(counters[i])+" razy")
    if(counters[i]>max):
        max=counters[i]
        maxIndex=i
print("Najczęściej wyrzucano "+str(maxIndex+1))