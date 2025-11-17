target=float(input("Podaj dystans do osiągnięcia: "))
current=float(input("Podaj dystans do przebiegnięcia bez przerwy: "))
profit=float(input("Procentowy wzrost na tydzień: "))

weeks=0
while current<target:
    current*=1+(profit/100)
    print(current)
    weeks+=1
print("Potrzeba "+str(weeks)+ " tygodni na osiągnięcie celu.")