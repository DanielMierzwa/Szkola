import random
def randomstr(n):
    str=""
    for i in range(0,n):
        str+=chr(random.randint(64,121))
    return str
def max(a,b,c):
    if a>b and a>c:
        return a
    if b>a and b>c:
        return b
    return c

def sum(tab):
    sum=0
    for x in tab:
        sum+=x
    return sum
def multiply(tab):
    sum=tab[0]
    for i in range(1,len(tab)):
        sum*=tab[i]
    return sum

def factorial(x):
    n=1
    for i in range(1,x+1):
        n*=i
    return n
def check(x, y1, y2):
    if x in range(y1, y2):
        return True
    return False

def find(str):
    small=0
    big=0
    for x in str:
        if x.isupper():
            big+=1
        else:
            small+=1
    return [small,big]
def groupBy(tab):
    return set(tab)

def prime(x):
    for i in range(2,x):
        if x%i==0:
            return False
    return True

def find2(tab):
    tab2=[]
    for x in tab:
        if x%2==0:
            tab2.append(x)
    return tab2
values=[]
print("Liczby:")
for i in range(5):
    values.append(random.randint(1, 10))
    print(str(values[i])+",", end="")

print("\nMax of 3 first:"+str(max(values[0],values[1],values[2])))
print("Sum of all:"+str(sum(values)))
print("Multiply all numbers:"+str(multiply(values)))
string=randomstr(5)
print(string+" reversed:"+string[::-1])
result=find(string)
print("Big letters:"+str(result[1])+" Small letters:"+str(result[0]))

print("Factorial of first:"+str(factorial(values[0])))
if check(values[0],5,10):
    print(str(values[0])+" is in range <5,10>",)
else:
    print(str(values[0])+" is not in range <5,10>",)

print("Unique list:"+str(groupBy(values)))

if(prime(values[0])):
    print(str(values[0])+" is prime")
else:
    print(str(values[0])+" is not prime")

print("Parzyste")
print(find2(values))



# See PyCharm help at https://www.jetbrains.com/help/pycharm/
