using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowShooterControl : MonoBehaviour
{
    

    [SerializeField]private Transform _projectileHolder;//Spawn place for the glow bullet
    [SerializeField]private Transform _glowArmObj;
    [SerializeField]private GameObject[] _glowPreFab;

    private GameObject _bulletInstance;
    public float _bulletSpeed;
    private Rigidbody2D _bulletRB;
    [HideInInspector]public bool _canShoot;
    private bool _canReload;

    private AudioSource glowShootSound;


    // Start is called before the first frame update
    void Start()
    {
        _canShoot = true;
        _canReload = false;

        if (_bulletRB == null)
        {
            return;
        }
    }

    private void OnEnable() {
        glowShootSound = GameObject.Find("GlowShootSound").GetComponent<AudioSource>();
    }

    private void OnDisable() {
        ReloadBullet();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerMovement.playerflipped)
        {
            _projectileHolder.localRotation = Quaternion.Euler(0, 180, 90);//flips the rotation so it can keep the same shooting dir
        }
        else
        {
            _projectileHolder.localRotation = Quaternion.Euler(0, 0, 90);//flips the rotation back to normal so it can keep the same shooting dir
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_canShoot && !PlayerMovement.isPossessing)
            {
                if (glowShootSound != null)
                {
                    glowShootSound.Play();
                }
                else
                {
                    return;
                }
                ShootBullet();
            }
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            if (_canShoot && !PlayerMovement.isPossessing)
            {
                if (glowShootSound != null)
                {
                    glowShootSound.Play();
                }
                else
                {
                    return;
                }
                ShootBullet();
            }
        }


    }

    private void ShootBullet()
    {
        _bulletInstance = Instantiate(_glowPreFab[Glow.glowType], _projectileHolder.position, _glowArmObj.rotation);
        _bulletRB = _bulletInstance.GetComponent<Rigidbody2D>();
        if (_canShoot)
        {
            _bulletRB.AddForce(_projectileHolder.up * _bulletSpeed, ForceMode2D.Impulse);
            _canShoot = false;
        } 
    }

    public void ReloadBullet()
    {
        _bulletRB = null;
        Destroy(_bulletInstance);
        _canShoot = true;
    }
}
