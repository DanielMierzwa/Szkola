x=True
while(x):
    dogAge=int(input("Podaj wiek psa: "))
    if dogAge<0:
        print("Wiek nie może być ujemny")
        continue
    hAge=0
    if dogAge>=1:
        hAge+=15
    if dogAge>=2:
        hAge+=9
    if dogAge>=3:
        hAge+=(dogAge-2)*5
    print("Wiek psa w ludzkich latach to "+str(hAge))
    x=False