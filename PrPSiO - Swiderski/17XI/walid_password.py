def walid_password(password):
    if(len(password)<8):
        return False

    haveUpper=False
    haveLower=False
    haveSpecial=False
    haveNumber=False
    for x in password:
        if(x.isupper()):
            haveUpper=True
        if x.islower():
            haveLower=True

        y=ord(x)
        # if y in range(33,48) or y in range(58,65) or y in range(91,97) or y in range(123,127):
        #     haveSpecial=True
        if y in range(48,58):
            haveNumber=True
    if not haveNumber or not haveUpper or not haveLower:
        return False
    return True

tab=["abc","ddwedwdAA","123456789","i1Arrrrr"]
for x in tab:
    print(str(x)+" walid:"+str(walid_password(x)))

