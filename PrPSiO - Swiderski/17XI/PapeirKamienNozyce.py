import os
import random


def check_result(player_choice,computer_choice):
    tab = ["kamien", "papier", "nozyce"]
    player_index=tab.index(player_choice)
    computer_index=tab.index(computer_choice)
    x=player_index-computer_index
    x=(x+len(tab))%len(tab)
    if x==1:
        return 1
    if x==0:
        return 0
    return -1

# arr=[["kamien","nozyce"],["kamien","papier"],["papier","nozyce"],["papier","kamien"]]
# for x in arr:
#     print(x)
#     print(check_result(x[0],x[1]))
tab = ["kamien", "papier", "nozyce"]
odp=-1
while(odp!=0):
    odp=input("Podaj swoj wybor:\n1 - kamien\n2- papier\n3 - nozyce\n:")
    if not (odp[0].isdigit()):
        odp=-1
        print("Nieprawidłowa odpowiedź")
    else:
        odp=int(odp)
    if(odp>0 and odp<4):
        computer_choice=tab[random.randint(0,2)]
        print("Komputer wybrał:"+computer_choice)
        check=check_result(tab[odp-1],computer_choice)
        if(check==1):
            print("Wygrales!")
        elif (check==-1):
            print("Przegrałeś!")
        else:
            print("Remis")