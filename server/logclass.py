
def LogInTxt(context):
	with open('log.txt', 'a') as file:
		file.write("{0}\n".format(context))