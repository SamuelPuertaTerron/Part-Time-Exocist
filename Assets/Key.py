import PIL
from PIL import Image as I
name = input('Name: ')
key = input('Key: ')
if key == '':
    key = "255,255,255,255"
new = input('New: ')
if new == '':
    new = "0,0,0,0"
klist = key.split(",")
nlist = new.split(",")
z = I.open(name+'.png')
a = z.convert('RGBA')
size = (a.size[0],a.size[1])
b = I.new('RGBA',size,(0,0,0))
c = b.load()
for i in range(size[0]):
    for j in range(size[1]):
        R,G,B,A  = a.getpixel((i,j))
        if R == int(klist[0]) and G == int(klist[1]) and B == int(klist[2]) and A == int(klist[3]):
            R,G,B,A = int(nlist[0]),int(nlist[1]),int(nlist[2]),int(nlist[3])
        #if (R+G+B)//3 > 200:
            #R,G,B,A = int(nlist[0]),int(nlist[1]),int(nlist[2]),int(nlist[3])
        c[i,j] = (R,G,B,A)
b.save(name+'.png')

