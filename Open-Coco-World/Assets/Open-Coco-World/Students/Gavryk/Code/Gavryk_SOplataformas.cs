using UnityEngine;

namespace OpenCocoWorld.Gavryk
{
    public class Gavryk_SOplataformas : MonoBehaviour
    {
        [SerializeField] Gavryk_PatronMovimientoPlataformasSO PatronMovimientoPlataformasSO;

        [SerializeField] Transform m_firstPosition;
        [SerializeField] Transform m_secondPosition;
        [SerializeField] float m_time;

        Vector3 m_Objetivo;
        Vector3 m_StartPos;

        void Start()
        {
            m_StartPos = m_firstPosition.position;
            m_Objetivo = m_secondPosition.position;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Objetivo, m_time * Time.deltaTime);

            if (Vector3.Distance(transform.position, m_Objetivo) < 0.1f)
            {
                m_Objetivo = (m_Objetivo == m_firstPosition.position) ? m_secondPosition.position : m_firstPosition.position;
            }
        }
    }
}