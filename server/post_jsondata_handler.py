
import json


def normal_post_json_handle(datas):
	jsonstring = datas.decode('utf-8')
	jsondatas = json.loads(jsonstring)
	jsonstring = json.dumps(jsondatas)
	return __post_json_handle_template(datas)

def simlpe_post_json_handle(datas):
	return __post_json_handle_template(datas, __simplehandle)

def __simplehandle(jsondatas):
	jsondatas['StringValue'] = jsondatas['StringValue'] + "_SimpleHandle"
	jsondatas['IntValue'] = jsondatas['IntValue'] + 100
	jsondatas['BoolValue'] = not jsondatas['BoolValue']

def __post_json_handle_template(datas, callback = None):
	jsonstring = datas.decode('utf-8')
	jsondatas = json.loads(jsonstring)
	if callback != None:
		callback(jsondatas)
	jsonstring = json.dumps(jsondatas)
	return jsonstring.encode('utf-8')