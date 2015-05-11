using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
	Rigidbody rigidbody;
	public float PlayerSpeed = 4.0f;
	private int groundLayerIndex=-1;
	Animator anim;
	private bool isMove=true;
	float joyPositionX;
	float joyPositionY;
	void OnEnable()
	{
		EasyJoystick.On_JoystickMove += OnJoystickMove;
		EasyJoystick.On_JoystickMoveEnd += OnJoystickMoveEnd;
	}
	//移动摇杆结束
	void OnJoystickMoveEnd(MovingJoystick move)
	{

		isMove=false;
	}
	
	
	//移动摇杆中
	void OnJoystickMove(MovingJoystick move)
	{
		if (move.joystickName != "MoveJoystick")
		{
			return;
		}
		
		//获取摇杆中心偏移的坐标
		joyPositionX = move.joystickAxis.x;
		joyPositionY = move.joystickAxis.y;
		
		isMove=true;
	}
	// Use this for initialization
	void Start ()
	{
		rigidbody = GameObject.Find ("MyPlayer").GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		groundLayerIndex=LayerMask.GetMask("Floor");
	}
	// Update is called once per frame
	void Update ()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if(Physics.Raycast(ray,out hitInfo,200,groundLayerIndex))
		{
			Vector3 target=hitInfo.point;
			target.y=transform.position.y;
			transform.LookAt(target);
		}



		if (joyPositionY != 0 || joyPositionX != 0)
		{
			Debug.Log("joyPositionX:"+joyPositionX+" joyPositionY:"+joyPositionY);
			Vector3 target;
			//设置角色的朝向（朝向当前坐标+摇杆偏移量）
			if(joyPositionX>0&&joyPositionY>0){
				target=new Vector3 (joyPositionX, 0, joyPositionY) * PlayerSpeed*5;
			}else if(joyPositionX<0&&joyPositionY>0){
				target=new Vector3 (joyPositionX, 0, joyPositionY) * PlayerSpeed*5;
			}
			else{
				target=new Vector3 (-joyPositionX, 0, -joyPositionY) * PlayerSpeed*5;

			}
			transform.LookAt(target);
			//transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
			//移动玩家的位置（按朝向位置移动）
			if(rigidbody!=null){
				rigidbody.MovePosition (transform.position + new Vector3 (joyPositionX, 0, joyPositionY) * PlayerSpeed*1.5f * Time.deltaTime);
			}
			//播放奔跑动画

		}

//		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
//			anim.SetBool ("Move", true);
//			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
//			rigidbody.MovePosition (transform.position + new Vector3 (touchDeltaPosition.x,0, touchDeltaPosition.y) * Time.deltaTime);
//		}else {
//			anim.SetBool ("Move", false);
//		}

//		if(isMove){
//			anim.SetBool ("Move", true);
//		}else{
//			anim.SetBool ("Move", false);
//		}

		if (h != 0 || v != 0) {
			anim.SetBool ("Move", true);
			rigidbody.MovePosition (transform.position + new Vector3 (h, 0, v) * PlayerSpeed * Time.deltaTime);

		} else if(isMove){
			anim.SetBool ("Move", true);
		}
		else {
			anim.SetBool ("Move", false);
		}


//		Debug.Log(EnemyTotal.Count);
	}
}
