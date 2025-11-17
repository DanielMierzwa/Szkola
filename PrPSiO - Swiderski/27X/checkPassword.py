badPassword=True
while(badPassword):
    password=input("\nPodaj hasło: ")
    changeStatus=True
    if(len(password)<8):
        changeStatus=False
        print("X Hasło ma poniżej 8 znaków")
    else:
        print("✓ Hasło ma powyżej 8 znaków")

    haveUpper=False
    # haveLower=False
    haveSpecial=False
    haveNumber=False
    for x in password:
        if(x.isupper()):
            haveUpper=True
        # if x.islower():
        #     haveLower=True

        y=ord(x)
        if y in range(33,48) or y in range(58,65) or y in range(91,97) or y in range(123,127):
            haveSpecial=True
        if y in range(48,58):
            haveNumber=True

    if haveUpper:
        print("✓ Ma przynajmniej jedną dużą literę")
    else:
        print("X Nie ma żadnej dużej litery")
        changeStatus=False
    # if haveLower:
    #     print("✓ Ma przynajmniej jedną małą literę")
    # else:
    #     print("X Nie ma żadnej małej litery")
    #     changeStatus=False
    if haveSpecial:
        print("✓ Ma przynajmniej jeden znak specjalny")
    else:
        print("X Nie ma żadnego znaku specjalnego")
        changeStatus=False
    if haveNumber:
        print("✓ Ma przynajmniej jeden numer")
    else:
        print("X Nie ma żadnego numeru")
        changeStatus=False

    if changeStatus==True:
        badPassword=False
print("Gratuluję porządnego hasła")