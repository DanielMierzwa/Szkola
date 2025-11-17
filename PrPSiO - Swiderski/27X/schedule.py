target=float(input("Podaj kwotę do osiągnięcia: "))
profit=float(input("Podaj co miesięczne oszczędności: "))
saldo=float(input("Podaj oprocentowanie miesięczne: "))

count=0
months=0
while count<target:
    count+=profit
    count*=1.0+(saldo/100.0)
    months+=1
print("Potrzeba "+str(months)+ " miesięcy na osiągnięcie celu.")